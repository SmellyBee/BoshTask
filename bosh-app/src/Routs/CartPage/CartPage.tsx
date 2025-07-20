import axios from "axios"
import { REACT_APP_API_URL } from "../../assets/consts"
import { useQuery } from "@tanstack/react-query";
import styles from "./CartPage.module.scss";
import CartItem, { CartItemProps } from "../../Components/CartItem/CartItem";
import BreadcrumbNav from "../../Components/BreadcrumbNav/BreadcrumbNav";

export default function CartPage()
{
    
    const fetchProducts = async () =>{
        const res = await axios.get(REACT_APP_API_URL+"/api/cart");
        return res.data;
    }

    const { data, isLoading,refetch } = useQuery({
        queryKey: [],
        queryFn: () => fetchProducts(),
        });

    if (isLoading) return <div className={styles.loader}></div>
        
            if (data.length  === 0) {
                return <div>No products found. 0 Products added to cart.</div>;
            }    

    return(
        <>
            <BreadcrumbNav productName="Cart" />
            
            <div className={styles.gridView}>
                {Array.isArray(data) && data.map((item) => (
                    <CartItem key={item.productInfo.id}
                        id={item.productInfo.id}
                        image={item.productInfo.image}
                        shortDescription={item.productInfo.shortDescription}
                        price={item.productInfo.price}
                        name={item.productInfo.name}
                        quantity={item.quantity}
                        addORupdate="update"
                    />
                ))}
            </div>
        </>
    )
}