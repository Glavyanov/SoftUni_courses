import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';

const baseUrl = 'https://swapi.dev/api';

export const CharacterFilms = () => {
    const [films, setFilms] = useState([]);
    const { characterId } = useParams();

    // fetch something like /people/${characterId}/films from swapi, but there is no such thing
    useEffect(() => {
        fetch(`${baseUrl}/films`)
            .then(res => res.json())
            .then(data => {
                setFilms(data.results);
            })
    }, [characterId]);
    

    return (
        <>
            <h1>Character Films</h1>

            {films.map(x => {
                const id = x.url.split('/').filter(x => x).pop();

                return <li key={id}><Link to={`/films/${id}`}>{x.title}</Link></li>}
            )}
        </>
    );
};
