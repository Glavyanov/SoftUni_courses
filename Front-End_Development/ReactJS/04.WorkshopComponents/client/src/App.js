import './App.css';
import { useEffect, useState } from 'react';
import * as userService from './services/userService';
import * as itemService from './services/itemService';
import { Footer } from './components/Footer';
import { Header } from './components/Header';
import { Search } from './components/Search';
import { UserList } from './components/UserList';
import { Routes, Route } from 'react-router-dom';
import { ItemList } from './components/ItemList';


function App() {

    const [users, setUsers] = useState([]);
    const [items, setItems] = useState([]);

    useEffect(() => {
        userService.getAll()
            .then(users => {
                setUsers(users);
            })
            .catch(err => {
                console.log(`Error: ${err}`);
            });

        itemService.getAll()
            .then(items => {
                setItems(items);
            })
            .catch(err => {
                console.log(`Error: ${err}`);
            });

    }, []);

    const onUserCreateSubmit = async (e) => {
        e.preventDefault();

        const formData = new FormData(e.currentTarget);
        const data = Object.fromEntries(formData);

        const createdUser = await userService.create(data);

        setUsers(state => [...state, createdUser]);
    };

    const onUserDelete = async (userId) => {

        await userService.remove(userId);
        setUsers(state => state.filter(x => x._id !== userId));
    };

    const onUserUpdateSubmit = async (e, userId) => {
        e.preventDefault();

        const formData = new FormData(e.currentTarget);
        const data = Object.fromEntries(formData);

        const updatedUser = await userService.update(userId, data);

        setUsers(state => state.map(x => x._id === userId ? updatedUser : x));
    };

    return (
        <>
            <Header />
            <main className="main">
                <section className="card users-container">
                    <Search />

                    <UserList
                        users={users}
                        onUserCreateSubmit={onUserCreateSubmit}
                        onUserDelete={onUserDelete}
                        onUserUpdateSubmit={onUserUpdateSubmit}
                    />
                </section>
                <Routes>
                    <Route path='/items' element={ <ItemList items={items} />} />
                </Routes>
            </main>
            <Footer />
        </>
    );
}

export default App;
