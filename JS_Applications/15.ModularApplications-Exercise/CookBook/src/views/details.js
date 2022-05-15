import { html } from '../../node_modules/lit-html/lit-html.js';
import * as dataServices from '../api/data.js';


const detailsTemplate = (recipe) => html`
<section id="details">
    <article>
        <h2>${recipe.name}</h2>
        <div class="band">
            <div class="thumb"><img src=${recipe.img}></div>
            <div class="ingredients">
                <h3>Ingredients:</h3>
                <ul>
                    ${recipe.ingredients.map(r => html`<li>${r}</li>`)}
                </ul>
            </div>
        </div>
        <div class="description">
            <h3>Preparation:</h3>
            ${recipe.steps.map(s => html`<p>${s}</p>`)}
        </div>

        <div class="controls">
            <a class="actionLink" href="/edit/${recipe._id}">Edit</a>
            <a class="actionLink" href="javascript:void(0)">Delete</a>
        </div>
    </article>

</section>`;

export function detailsPage(ctx) {
    const recipe =  ctx.recipe;
    ctx.render(detailsTemplate(recipe));
}

/**<div>
        <div class="section-title">
            Comments for Grilled Duck Fillet
        </div>
        <article class="new-comment">
            <h2>New comment</h2>
            <form id="commentForm">
                <textarea name="content" placeholder="Type comment"></textarea>
                <input type="submit" value="Add comment">
            </form>
        </article>
        <div class="comments">
            <ul>
                <li class="comment">
                    <header>peter@abv.bg</header>
                    <p> Great recipe!</p>
                </li>
            </ul>
        </div>
    </div> */