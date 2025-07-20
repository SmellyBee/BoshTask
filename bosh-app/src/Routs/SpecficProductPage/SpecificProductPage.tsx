import { useParams,useNavigate } from "react-router-dom";
import styles from "./SpecificProductPage.module.scss"
import { useQuery } from "@tanstack/react-query";
import { REACT_APP_API_URL } from "../../assets/consts";
import axios from "axios";
import Gallery from "../../Components/Gallery/Gallery";
import AddToCartButton from "../../Components/AddToCartButton/AddToCartButton";
import TechSpecTable from "../../Components/TechSpecTable/TechSpecTable";
import BreadcrumbNav from "../../Components/BreadcrumbNav/BreadcrumbNav";
import { useEffect, useState } from "react";

export default function SpecificProductPage()
{
    const { id } = useParams<{ id: string }>();
    const navigate = useNavigate();

    const fetchProduct = async () => {
     
            const res = await axios.get(REACT_APP_API_URL+`/api/products/${id}`);
            return res.data;
        
    };

    const { data, isLoading,error } = useQuery({
    queryKey: ['product'],
    queryFn: () => fetchProduct(),
    });
    
    useEffect(() => {
        if (error) {
            navigate("/404");
        }
    }, [error, navigate]);

    const [itemQuantity,setItemQuantity] = useState(0);
    
        const handleItemQuantityChnage = (e: React.ChangeEvent<HTMLInputElement>) =>{
    
            setItemQuantity(parseInt(e.target.value));
        }
    
    if (isLoading) return <div className={styles.loader}></div>


    return(
        <>
            <BreadcrumbNav productName={data.name} />

            <Gallery img_list={data.images}></Gallery>

            <div className={styles.contentDiv}>
                <div className={styles.content}>
                    <p className={styles.name}>Name: {data.name}</p>
                    <p className={styles.descrition}>Description: {data.fullDescription}</p>
                    <p className={styles.price}>Price: {data.price} RSD</p>

                    <div className={styles.cartActions}>

                    <input type="number" min="1" className={styles.quantityInput} value={itemQuantity} 
                        onChange={handleItemQuantityChnage}
                    />
                    <AddToCartButton className={styles.addButton}
                        quantity={itemQuantity}
                        itemId={parseInt(id ?? '0',10)}
                        addORupdate="add">    
                        Add to cart</AddToCartButton>
                </div>
                
                </div>
                <div className={styles.specTableWrapper}>
                    <TechSpecTable techSpec={data.techSpec}></TechSpecTable>
                </div>

            </div>
        </>
    )
}