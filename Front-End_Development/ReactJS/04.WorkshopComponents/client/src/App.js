import './App.css';
import { useEffect, useState } from 'react';
import * as userService from './services/userService';
import * as itemService from './services/itemService';
import { Home } from './components/Home';
import { Routes, Route } from 'react-router-dom';
import { ItemList } from './components/ItemList';

const errors = {};
function App() {

    const [users, setUsers] = useState([]);
    const [items, setItems] = useState([]);
    const [formValues, setFormValues] = useState({
        firstName: '',
        lastName: '',
        email: '',
        imageUrl: '',
        phoneNumber: '',
        country: '',
        city: '',
        street: '',
        streetNumber: '',
    });
    const [formErrors, setFormErrors] = useState({});

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

    useEffect(() => {
        setFormErrors(errors);
    }, [formValues]);

    const onUserCreateSubmit = async (e) => {
        e.preventDefault();

        const createdUser = await userService.create(formValues);
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


    const formChangeHandler = (e) => {

        const value = e.target.value;

        if (e.target.name === 'firstName' && (value.length < 3 || value.length > 20 || /^\s*$/.test(value))) {
            errors.firstName = 'First name should be at least 3 characters long!';
        }

        if (e.target.name === 'lastName' && (value.length < 3 || value.length > 20 || /^\s*$/.test(value))) {
            errors.lastName = 'Last name should be at least 3 characters long!';
        }

        if (e.target.name === 'email' && !/^[A-Za-z0-9_.]+@[A-Za-z]+\.[A-Za-z]{2,3}$/.test(value)) {
            errors.email = 'Email is not valid!';
        }

        if (e.target.name === 'imageUrl' && !/^https?:\/\/.+/.test(value)) {
            errors.imageUrl = 'ImageUrl is not valid!';
        }

        if (e.target.name === 'phoneNumber' && !/^0[1-9]{1}[0-9]{8}$/.test(value)) {
            errors.phoneNumber = 'Phone number is not valid!';
        }

        if (e.target.name === 'country' && (value.length < 2 || value.length > 20 || /^\s*$/.test(value))) {
            errors.country = 'Country should be at least 2 characters long!';
        }

        if (e.target.name === 'city' && (value.length < 2 || value.length > 20 || /^\s*$/.test(value))) {
            errors.city = 'City should be at least 3 characters long!';
        }

        if (e.target.name === 'street' && (value.length < 2 || value.length > 20 || /^\s*$/.test(value))) {
            errors.street = 'Street should be at least 3 characters long!';
        }

        if (e.target.name === 'streetNumber' && (Number(value) < 1)) {
            errors.streetNumber = 'Street number should be a positive number!';
        }

        setFormValues(state => ({ ...state, [e.target.name]: e.target.value }));

        if (formValues.firstName.length >= 2 && formValues.firstName.length <= 20) {
            errors.firstName = '';
        }

        if (formValues.lastName.length >= 2 && formValues.lastName.length <= 20) {
            errors.lastName = '';
        }

        if (/^[A-Za-z0-9_.]+@[A-Za-z]+\.[A-Za-z]{2,3}$/.test(formValues.email)) {
            errors.email = '';
        }

        if (/^https?:\/\/.+/.test(formValues.imageUrl)) {
            errors.imageUrl = '';
        }

        if (/^0[1-9]{1}[0-9]{8}$/.test(formValues.phoneNumber)) {
            errors.phoneNumber = '';
        }

        if (formValues.country.length >= 1 && formValues.country.length <= 20) {
            errors.country = '';
        }

        if (formValues.city.length >= 2 && formValues.city.length <= 20) {
            errors.city = '';
        }

        if (formValues.street.length >= 2 && formValues.street.length <= 20) {
            errors.street = '';
        }

        if (Number(formValues.streetNumber) > 1) {
            errors.streetNumber = '';
        }
    };

    const resetFormValues = () => {
        setFormValues({
            firstName: '',
            lastName: '',
            email: '',
            imageUrl: '',
            phoneNumber: '',
            country: '',
            city: '',
            street: '',
            streetNumber: '',
        })
    }

    return (
        <>
            <Routes>
                <Route path='/' element={<Home users={users}
                    onUserCreateSubmit={onUserCreateSubmit}
                    onUserDelete={onUserDelete}
                    onUserUpdateSubmit={onUserUpdateSubmit}
                    formValues={formValues}
                    formChangeHandler={formChangeHandler}
                    formErrors={formErrors}
                    resetFormValues={resetFormValues}
                />}
                />
                <Route path='/items' element={<ItemList items={items} />} />
            </Routes>
        </>
    );
}

export default App;
