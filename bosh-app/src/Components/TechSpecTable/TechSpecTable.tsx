import { unitMap } from "../../assets/consts";
import styles from "./TechSpecTable.module.scss"
type TechSpecTableProps = {
  techSpec: Record<string, string | number | null>;
};
export default function TechSpecTable({techSpec}:TechSpecTableProps)
{
    function toLabel(str: string) {
        return str
            .replace(/([A-Z])/g, ' $1')
            .replace(/^./, s => s.toUpperCase());
}
    return(
        <>
            <table className={styles.techSpecTable}>
                <thead>
                    <tr>
                    <th>Specification</th>
                    <th>Value</th>
                    </tr>
                </thead>
                    <tbody>
                       {Object.entries(techSpec)
                            .filter(([key, value]) => value !== null && value!== "N/A")
                            .map(([key, value]) => (
                                <tr key={key}>
                                    <td>{toLabel(key)}</td>
                                    <td>{value} {unitMap[key] || ""}</td>
                            </tr>
                        ))}
                    </tbody>
            </table>

        </>
    )
}