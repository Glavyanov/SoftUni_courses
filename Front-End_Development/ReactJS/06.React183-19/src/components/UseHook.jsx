
import { use, Suspense } from 'react';

const wait = (ms) => new Promise(resolve => setTimeout(resolve, ms));

async function fetchCharacter(id) {
    await wait(2000);
    const response = await fetch(`https://swapi.dev/api/people/${id}`);

    return response.json();
}

function Character(props) {
    const character = use(fetchCharacter(props.id))

    return <div>SW Character: {character.name}</div>;
}

export default function UseHook() {
    return (
        <>
            <h2>use Hook</h2>

            <Suspense fallback={<p>loading...</p>}>
                <Character id="4" />
            </Suspense >
        </>
    );
}
