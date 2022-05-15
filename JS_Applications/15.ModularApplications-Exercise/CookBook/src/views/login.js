import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../api/data.js';
import { createSubmitHandler } from '../util.js';

const loginTemplate = (onSubmit) => html`
<section id="login">
    <article>
        <h2>Login</h2>
        <form @submit=${onSubmit} id="loginForm">
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input type="submit" value="Login">
        </form>
    </article>
</section>`;

export function loginPage(ctx) {
    ctx.render(loginTemplate(createSubmitHandler(ctx, onSubmit)));

}

async function onSubmit(ctx, data, event){
    ctx.render(html`<h4>Loading &hellip;</h4>`);
    await login(data.email, data.password);
    event.target.reset();
    ctx.page.redirect('/catalog');
}