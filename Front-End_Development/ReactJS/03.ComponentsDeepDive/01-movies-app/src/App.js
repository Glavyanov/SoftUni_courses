import './App.css';
import { useEffect, useState } from 'react';
import MovieList from './components/MovieList';

function App() {

    const [movies, setMovies] = useState([]);

    useEffect(()=>{
        fetch('http://localhost:3000/movies.json')
        .then(res => res.json())
        .then(data => setMovies(data.movies.slice(20, 30)));
    },[]);
    

    const onMovieDelete = (id) => {
        setMovies(m => m.filter(x => x.id !== id));
    };

    const onMovieSelected = (id) => {
        setMovies(m => m.map(x => ({...x, selected: x.id === id})));
    };

    return (
        <div className="movie-app">
            <h1 className="h1">Favourite Movies</h1>
            <MovieList movies={movies} onMovieDelete={onMovieDelete} onMovieSelected={onMovieSelected}/>
        </div>
    );
}

export default App;
