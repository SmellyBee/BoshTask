
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import styles from "./CartIcon.module.scss"
import { faShoppingCart } from "@fortawesome/free-solid-svg-icons";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { REACT_APP_API_URL } from "../../assets/consts";
import { useQuery } from "@tanstack/react-query";


export default function CartItem()
{
    const navigate = useNavigate();

    const fetchProducts = async () =>{
        const res = await axios.get(REACT_APP_API_URL+"/api/cart");
        return res.data;
    }

    const { data, isLoading,refetch } = useQuery({
        queryKey: [],
        queryFn: () => fetchProducts(),
        });

    return(
        <>
           <div className={styles.cartHeaderContainer}>
                <div className={styles.cartContainer}>
                    <FontAwesomeIcon icon={faShoppingCart} size="2x" onClick={()=>navigate("/cart")} />
                    <span className={styles.cartBadge}>{Array.isArray(data) ? data.length : 0}</span>
                </div>
            </div>
        </>
    )
}