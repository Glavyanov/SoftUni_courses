import Movie from "./Movie";
import styles from './MovieList.module.css';

export default function MovieList({
    movies,
    onMovieDelete,
    onMovieSelected,
}) {

    return (
        <ul className={styles['ul']}>
            {movies.map(m =>
                <li key={m.id} className={styles['li']}>
                    <Movie {...m} onMovieDelete={onMovieDelete} onMovieSelected={onMovieSelected}/>
                </li>)}
        </ul>
    );
}