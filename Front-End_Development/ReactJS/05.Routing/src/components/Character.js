import { useEffect, useState } from 'react';
import { useParams, useNavigate, Routes, Route } from 'react-router-dom';
import { CharacterFilms } from './CharacterFilms';
import { Navigation, NavItem } from './Navigation';

const baseUrl = 'https://swapi.dev/api/people';

export const Character = () => {
    const { characterId } = useParams();
    const navigate = useNavigate();
    const [character, setCharacter] = useState({});

    useEffect(() => {
        fetch(`${baseUrl}/${characterId}`)
            .then(res => res.json())
            .then(data => {
                setCharacter(data);
            })
    }, [characterId])

    const onBackButtonClick = () => {
        navigate('/characters');
    };

    return (
        <>
            <h1>Character Page</h1>
            <h2>{character.name}</h2>
            <button onClick={onBackButtonClick}>Back</button>

            <Navigation>
                <NavItem to="films">Films</NavItem>
                <NavItem to="vehicles">Vehicles</NavItem>
                <NavItem to="starships">Starships</NavItem>
            </Navigation>

            <Routes>
                <Route path="/films" element={<CharacterFilms />} />
                <Route path="/vehicles" element={<h5>Vehicles</h5>} />
                <Route path="/starships" element={<h5>Starships</h5>} />
            </Routes>
        </>
    );
};