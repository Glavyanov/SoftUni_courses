import { html } from '../../node_modules/lit-html/lit-html.js';
import * as dataServices from '../api/data.js';

const catalogTemplate = (recipes) => html`
<section id="catalog">
    <div class="section-title">
        <form id="searchForm">
            <input type="text" name="search" value="">
            <input type="submit" value="Search">
        </form>
    </div>
    <header class="section-title">
        Page 1 of 1
    </header>
        ${recipes.map(recipeTemplate)}
    <footer class="section-title">
        Page 1 of 1
    </footer>
</section>`;

const recipeTemplate = (recipe) => html`
<a class="card" href="/catalog/${recipe._id}">
    <article class="preview">
        <div class="title">
            <h2>${recipe.name}</h2>
        </div>
        <div class="small"><img src=${recipe.img}></div>
    </article>
</a>`;

export async function catalogPage(ctx) {
    ctx.render(html`<h4>Loading &hellip;</h4>`);
    const recipes = await dataServices.getAll();

    ctx.render(catalogTemplate(recipes));
}