import { useState } from "react";
import AddToCartButton from "../AddToCartButton/AddToCartButton";
import styles from "./CartItem.module.scss"
export type CartItemProps =
{
    id: number;
    image: string;
    name: string;
    price: number;
    shortDescription: string;
    quantity?:number;
    addORupdate:string;
}
export default function CartItem({id,image,name,price,shortDescription,quantity,addORupdate}:CartItemProps)
{
    const [itemQuantity,setItemQuantity] = useState(quantity??0);

    const handleItemQuantityChnage = (e: React.ChangeEvent<HTMLInputElement>) =>{

        setItemQuantity(parseInt(e.target.value));
    }

    return(
        <>
            <div className={styles.cart}>
                
                <div className={styles.cartImgWrap}>
                    <img src={image} alt={name} />
                </div>
                
                <div className={styles.cartInfo}>
                    <p className={styles.textTitle}>{name}</p>
                    <p className={styles.textBody}>{shortDescription}</p>
                </div>

                <div className={styles.cartFooter}>
                    <p className={styles.priceTitle}>{price} RSD</p>
                </div>

                <div className={styles.cartActions}>
                    <input type="number" min="1" className={styles.quantityInput} value={itemQuantity} 
                        onChange={handleItemQuantityChnage}
                    />
                    <AddToCartButton className={styles.addButton}
                        quantity={itemQuantity}
                        itemId={id}
                        addORupdate = {addORupdate}
                        originalQuantity={quantity}
                        >
                            {addORupdate === "add"? "Add to cart" : "Update quantity"}</AddToCartButton>
                </div>

            </div>
        </>
    );
}