import { Link } from "react-router-dom";
import styles from "./BreadcrumbNav.module.scss"
type BreadcrumbProps = {
  productName: string;
};
export default function BreadcrumbNav({productName}:BreadcrumbProps)
{
    return(
        <>
            <nav className={styles.breadcrumb}>
                <Link to="/">Products</Link>
                <span> &gt; </span>
                <span>{productName}</span>
            </nav>
        </>
    )
}