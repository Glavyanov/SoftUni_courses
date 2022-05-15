import { clearUserData, getUserData, setUserData } from '../util.js';

const host = 'http://localhost:3030';


async function request(url, options) {
    
    try {
        const responce = await fetch(host + url, options);

        if (responce.ok != true) {
            if (responce.status == 403) {
                sessionStorage.removeItem('userData');
            }
            const error = await responce.json();
            throw new Error(error.message);
        }

        if (responce.status == 204) {
            return responce;
        } else {
            return responce.json();
        }

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

function createOptions(method = 'get', data) {
    const options = {
        method,
        headers: {}
    };

    if (data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userData = getUserData();
    if (userData != null) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('post', data));
}

export async function put(url, data) {
    return request(url, createOptions('put', data));
}

export async function del(url) {
    return request(url, createOptions('delete'));
}

export async function login(email, password) {
    const result = await post('/users/login', { email, password });

    const userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    };
    setUserData(userData);
}

export async function register(email, password){
    const result = await post('/users/register', { email, password });

    const userData = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    };
    setUserData(userData);
}

export async function logout(){
    await get('/users/logout');
    clearUserData();
}