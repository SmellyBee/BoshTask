import { useEffect, useState } from "react";
import styles from "./Gallery.module.scss"
type GalleryProps=
{
    img_list:string[];
}
export default function Gallery({img_list}:GalleryProps)
{
    const [currentIndex, setCurrentIndex] = useState(0);

    useEffect(() => {
    const interval = setInterval(() => {
      setCurrentIndex((prevIndex) =>
        prevIndex === img_list.length - 1 ? 0 : prevIndex + 1
      );
    }, 6000);
    return () => clearInterval(interval); 

  }, []);
    console.log(img_list);
    return(
        <>
            <div className={styles.gallery}>
            <img src={`/${img_list[currentIndex]}`} alt={`Image ${currentIndex + 1}`} className={styles.image} />
            <div className={styles.paginationDots}>
                {img_list.map((_, i) => (
                    <div
                    key={i}
                    className={`${styles.dot} ${i === currentIndex ? styles.active : ''}`}
                />
                ))}
            </div>

        </div>
        </>
    )
}