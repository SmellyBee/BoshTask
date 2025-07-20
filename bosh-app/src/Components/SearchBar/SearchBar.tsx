import { useEffect, useState } from 'react';
import styles from './SearchBar.module.scss'
import { useDebounce } from 'use-debounce';
type SearchBarProps=
{
    onSearchChange: (value: string) => void;
}
export default function SearchBar({onSearchChange}:SearchBarProps)
{
    const [inputValue, setInputValue] = useState('');
    const [debouncedValue] = useDebounce(inputValue, 300); 

    useEffect(() => {
    onSearchChange(debouncedValue);
    }, [debouncedValue, onSearchChange]);

    return(
        <>
            <input
                type="text"
                placeholder="Search products by name..."
                value={inputValue}
                onChange={e => setInputValue(e.target.value)}
                className={styles.searchBar}
                />
        </>
    )
}