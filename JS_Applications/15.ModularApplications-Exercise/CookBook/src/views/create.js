import { html } from '../../node_modules/lit-html/lit-html.js';

const createTemplate = () => html`
<section id="create">
    <article>
        <h2>New Recipe</h2>
        <form id="createForm">
            <label>Name: <input type="text" name="name" placeholder="Recipe name"></label>
            <label>Image: <input type="text" name="img" placeholder="Image URL"></label>
            <label class="ml">Ingredients: <textarea name="ingredients"
                    placeholder="Enter ingredients on separate lines"></textarea></label>
            <label class="ml">Preparation: <textarea name="steps"
                    placeholder="Enter preparation steps on separate lines"></textarea></label>
            <input type="submit" value="Create Recipe">
        </form>
    </article>
</section>`;

export function createPage(ctx) {
    ctx.render(html`<h4>Loading &hellip;</h4>`);
    ctx.render(createTemplate());
}