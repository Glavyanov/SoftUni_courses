import './App.css';
import Counter from './components/Counter';
import MovieList from './components/MovieList';
import Timer from './components/Timer';

function App() {

    return (
        <div className="App">
            <h1>React Demo</h1>
            <Timer start={0}/>
            <Counter reset />
            <article>
                <h2>Movie List</h2>
                <MovieList />
            </article>
        </div>
    );
}

export default App;
