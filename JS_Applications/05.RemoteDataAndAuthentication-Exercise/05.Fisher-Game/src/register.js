import { displayUser, setUser, hideLogoutBtn } from './app.js';

displayUser();
hideLogoutBtn();

const url = 'http://localhost:3030/users/register';
const registerBtn = document.querySelector('#register button');
const formElement = document.querySelector('#register-view #register');

registerBtn.addEventListener('click', registerUser);

async function registerUser(e) {
    e.preventDefault();
    registerBtn.disabled = true;
    let form = new FormData(formElement);
    const email = form.get('email');
    const password = form.get('password');
    const rePass = form.get('rePass');

    if (!email || !password || !rePass || password !== rePass || !email.search(/^\s*$/)
        || !password.search(/^\s*$/) || !rePass.search(/^\s*$/)) {
        alert('Unsuccessful register');
        registerBtn.disabled = false;
        return;

    }
    try {
        registerBtn.textContent = 'Loading...';

        const res = await fetch(url, {
            method: "POST",
            headers: {
                "content-type": "appliction/json"
            },
            body: JSON.stringify({ email, password })
        });
        if (!res.ok) {
            if (res.status == 409) {
                registerBtn.textContent = 'Register';
                alert('A user with the same email already exists');
                return;
            }
        }
        let data = await res.json();

        registerBtn.textContent = 'Register';
        setUser(data, 'Successful register', registerBtn, formElement);

    } catch (error) {
        registerBtn.textContent = 'Register';
        alert('Error');
    }

    registerBtn.disabled = false;
}
