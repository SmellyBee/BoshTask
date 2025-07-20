import axios from "axios"
import { REACT_APP_API_URL } from "./consts"

export const addItemsToCart = async (itemId:number,quantity:number,toast: (message: string, options?: object) => void)=>{
    try
    {
        for(let i=0;i<quantity;i++)
        {
            await axios.post(REACT_APP_API_URL+`/api/cart/add?id=${itemId}`);
        }
        toast("Successfully added items to cart!", { type: "success" });
    }catch (error: any) {
        toast("Failed to add items", { type: "error" });
    }
}

export const updateItemsToCart = async(itemId:number,quantity:number,toast: (message: string, options?: object) => void,
    originalQuantity:number|undefined) =>{
    try{
        let update = quantity - (originalQuantity??0);
        console.log(quantity);
        console.log(originalQuantity);
        console.log(update);
        if(update > 0) 
        {
            for(let i=0;i<update;i++)
            {    
                await axios.post(REACT_APP_API_URL+`/api/cart/add?id=${itemId}`);
            }

            toast("Successfully updated item of cart!", { type: "success" });
        }
        else
        {
            for(let i=0;i<-update;i++)
            {
                await axios.delete(REACT_APP_API_URL+`/api/cart/item/${itemId}`);
            }
            toast("Successfully deleted item of cart!", { type: "success" });
        }       

    }catch(error:any)
    {
        toast("Failed to update item", { type: "error" });
    }
}