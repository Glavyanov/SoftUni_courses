import { getUserData } from '../util.js';

const userLinks = document.getElementById('user');
const guestLinks = document.getElementById('guest');

const links = {
    '/catalog': document.getElementById('catalogLink'),
    '/create': document.getElementById('createLink'),
    '/login': document.getElementById('loginLink'),
    '/register': document.getElementById('registerLink'),
};


export function updateNav(ctx,next){

    Object.values(links).forEach(l => l.classList.remove('active'));
    const current =links[ctx.pathname];
    if (current) {
        current.classList.add('active');
    }

    const user = getUserData();

    if (user) {
        userLinks.style.display = 'inline-block';
        guestLinks.style.display = 'none';
    }else{
        userLinks.style.display = 'none';
        guestLinks.style.display = 'inline-block';
    }
    next();
}