import { useEffect } from "react";
import styles from "./Movie.module.css"

export default function Movie({
    id,
    title,
    year,
    plot,
    posterUrl,
    director,
    selected=false,
    onMovieDelete,
    onMovieSelected,
}){
    useEffect(()=> {
        console.log(`${title} id:${id} - ${!selected ? 'mounted' : 'selected'}`);
    },[title,id,selected]);

    useEffect(()=>{
        return () =>{
            console.log(`${title} - unmounted`)
        };
    },[title]);

    return(
        <article className={`${styles['article']}${selected ? ` ${styles['selected']}`: ''}`} >
            <h3 style={{margin:'unset', padding: '20px 0'}}>{title}, {year}</h3>
            <section>
                <img src={posterUrl} alt={title} />
                <p>{plot}</p>
            </section>
            <footer>
                <p>{director}</p>
                <button onClick={() => onMovieDelete(id)}>Delete</button>
                <button onClick={() => onMovieSelected(id)}>Select</button>
            </footer>
        </article>
    );
};