import { displayUser, setUser, hideLogoutBtn } from './app.js';

displayUser();
hideLogoutBtn();

const loginBtn = document.querySelector('#login-view button');
const url = 'http://localhost:3030/users/login';

loginBtn.addEventListener('click', loginUser);

async function loginUser(e) {
    e.preventDefault();

    const formElement = e.currentTarget.parentElement;
    let form = new FormData(formElement);

    const email = form.get('email');
    const password = form.get('password');
    if (!email || !password || !email.search(/^\s*$/) || !password.search(/^\s*$/)) {
        alert('Email and Password cannot be empty');
        return;
    }
    try {
        loginBtn.disabled = true;
        loginBtn.textContent = 'Loading...';
        const res = await fetch(url, {
            method: "POST",
            headers: {
                "content-type": "application/json"
            },
            body: JSON.stringify({ email, password })
        });
        if (res.status != 200) {
            formElement.reset();
            loginBtn.disabled = false;
            loginBtn.textContent = 'Login';
            alert('unsuccessful login');

            return;
        }
        const data = await res.json();

        loginBtn.textContent = 'Login';
        setUser(data,'Successful login',loginBtn, formElement);

    } catch (error) {
        loginBtn.disabled = false;
        loginBtn.textContent = 'Login';
        alert('Error');

    }
}