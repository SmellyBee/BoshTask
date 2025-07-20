import axios from "axios";
import { NUMBER_OF_PRODUCTS, REACT_APP_API_URL } from "../../assets/consts";
import styles from "./Pagination.module.scss"
import { useQuery } from "@tanstack/react-query";
import { useEffect, useState } from "react";
type PaginationProps={
    numberOfItems: number;
    onDataFetched: (data: any[]) => void;
}
export default function Pagination({numberOfItems,onDataFetched}:PaginationProps)
{
    const [currentPage, setCurrentPage] = useState(1);
    
    const fetchProducts = async (pageNumber:number,pageSize:number) => {
            const res = await axios.get(REACT_APP_API_URL+`/api/products?page=${pageNumber}&pageSize=${pageSize}`);
        return res.data;
        };
        
        const numberOfPages = Math.ceil(NUMBER_OF_PRODUCTS / numberOfItems);

        const { data, isLoading,refetch } = useQuery({
        queryKey: ['product',currentPage, numberOfItems],
        queryFn: () => fetchProducts(currentPage, numberOfItems),
        });

        const nextPage = (index:number) =>{
            setCurrentPage(index + 1);
            refetch();
        }
        const handlePrevious = () => {
            if (currentPage > 0) setCurrentPage(currentPage-1);
            refetch();
        };

        const handleNext = () => {
            if (currentPage-1 < numberOfPages) setCurrentPage(currentPage + 1);
            refetch();
        };

        useEffect(() => {
            if (data && Array.isArray(data)) {
                onDataFetched(data); 
            }
        }, [data, onDataFetched]);

        if (isLoading) return <div className={styles.loader}></div>
        
            if (data.length  === 0) {
                return <div>No products found. Try again later</div>;
            }
    return(
        <>
            <div className={styles.pagination}>

                    <button
                        onClick={handlePrevious}
                        disabled={currentPage === 1}
                        className={styles.arrowBtn}>
                        ← Previous
                    </button>

                    {Array.from({ length: numberOfPages }, (_, index) => (
                        <button
                        key={index}
                        onClick={() => nextPage(index)}
                        className={currentPage === index + 1 ? styles.active : styles.pageButton}
                        disabled={currentPage === index + 1}
                        >
                        {index + 1}
                        </button>
                    ))}

                    <button
                        onClick={handleNext}
                        disabled={currentPage === numberOfPages}
                        className={styles.arrowBtn}
                        >
                        Next →
                        </button>
                    
            </div>

        </>
    )
}