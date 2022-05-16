import { html, render } from '../../node_modules/lit-html/lit-html.js';

const root = document.querySelector('#box header');

const userLinks = html`
<li><a href="/create">Create Album</a></li>
<li><a href="/logout">Logout</a></li>
`;

const guestLinks = html`
<li><a href="/login">Login</a></li>
<li><a href="/register">Register</a></li>
`;

const navigationTemplate = (accessToken) => html`
<nav>
    <img src="/images/headphones.png">
    <a href="/">Home</a>
    <ul>
        <li><a href="/catalog">Catalog</a></li>
        <li><a href="/search">Search</a></li>
        ${accessToken
          ? userLinks
          : guestLinks 
          }
    </ul>
</nav>`;


export function updateNav(ctx, next) {
    const userToken = ctx.user()?.token;
    render(navigationTemplate(userToken), root);
    next();
}