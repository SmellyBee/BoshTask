import { addItemsToCart, updateItemsToCart } from "../../assets/add_update_ItemsToCartFunc";
import { toast } from "react-toastify";

type ButtonProps={
    children: React.ReactNode;
    className?: string;
    quantity: number;
    itemId: number;
    addORupdate:string;
    originalQuantity?: number;
}
export default function AddToCartButton({children,className,quantity,itemId,addORupdate,originalQuantity}:ButtonProps)
{

    return(
        <>
            <button className={className} 
            onClick={()=> addORupdate === "add" ? addItemsToCart(itemId,quantity,toast):
                updateItemsToCart(itemId,quantity,toast,originalQuantity)}>
                {children}</button>
        </>
    )
}