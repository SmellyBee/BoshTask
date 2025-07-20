import {  useMemo, useState } from "react";
import CartItem from "../../Components/CartItem/CartItem";
import styles from "./CartItemsPage.module.scss"
import type { CartItemProps } from "../../Components/CartItem/CartItem";
import SearchBar from "../../Components/SearchBar/SearchBar";
import Pagination from "../../Components/Pagination/Pagination";

export  default function CartItemsPage()
{
    const [isGrid, setIsGrid] = useState(true);
    const [sortOption, setSortOption] = useState('priceAsc');
    const [itemNumber,setItemNumber] = useState(5);
    const [data,setData] = useState<CartItemProps[]>([]);


    const[searchTerm,setSearchTerm] = useState("");

    const sortedProducts = useMemo(() => {
        const filteredProducts = Array.isArray(data)? data.filter((product: { name: string }) =>
        product.name.toLowerCase().includes(searchTerm.toLowerCase())) : [];

       switch (sortOption) {
            case 'priceAsc':
            return filteredProducts.sort((a, b) => a.price - b.price);
            case 'priceDesc':
            return filteredProducts.sort((a, b) => b.price - a.price);
            case 'nameAsc':
            return filteredProducts.sort((a, b) =>
                a.name.localeCompare(b.name)
            );
            case 'nameDesc':
            return filteredProducts.sort((a, b) =>
                b.name.localeCompare(a.name)
            );
            default:
            return filteredProducts;
        } 
       
    }, [data, searchTerm,sortOption]);


    return(
        <>
            <SearchBar onSearchChange={setSearchTerm}></SearchBar>
            <button onClick={() => setIsGrid(!isGrid)} className={styles.toggleButton}>
                    Switch to {isGrid ? 'List' : 'Grid'} View
            </button>
            <div className={styles.sortingDiv}>
                <select
                value={itemNumber}
                onChange={(e) => setItemNumber(parseInt(e.target.value))}
                className={styles.sortSelect}>
                <option value={5}>Show 5 items per page</option>
                <option value={10}>Show 10 items per page</option>
                <option value={15}>Show 15 items per page</option>
                <option value={20}>Show 20 items per page</option>
                </select>
            </div>

            <div className={styles.sortingDiv}>
                <select
                value={sortOption}
                onChange={(e) => setSortOption(e.target.value)}
                className={styles.sortSelect}>
                <option value="priceAsc">Price: Low to High</option>
                <option value="priceDesc">Price: High to Low</option>
                <option value="nameAsc">Name: A to Z</option>
                <option value="nameDesc">Name: Z to A</option>
                </select>
            </div>

            <Pagination numberOfItems={itemNumber} onDataFetched={setData} />

           <div className={isGrid ? styles.gridView : styles.listView}>
                {Array.isArray(sortedProducts) && sortedProducts.map((item: CartItemProps) => (
                    <CartItem key={item.id} {...item} addORupdate="add"/>
                ))}
            </div>
        </>
    )
}