import { html } from '../../node_modules/lit-html/lit-html.js';

const editTemplate = () => html`
<section id="edit">
    <article>
        <h2>Edit Recipe</h2>
        <form id="editForm">
            <input type="hidden" name="_id" value="3987279d-0ad4-4afb-8ca9-5b256ae3b298">
            <label>Name: <input type="text" name="name" placeholder="Recipe name"></label>
            <label>Image: <input type="text" name="img" placeholder="Image URL"></label>
            <label class="ml">Ingredients: <textarea name="ingredients"
                    placeholder="Enter ingredients on separate lines"></textarea></label>
            <label class="ml">Preparation: <textarea name="steps"
                    placeholder="Enter preparation steps on separate lines"></textarea></label>
            <input type="submit" value="Save Changes">
        </form>
    </article>
</section>`;

export function editPage(ctx) {
    ctx.render(html`<h4>Loading &hellip;</h4>`);
    ctx.render(editTemplate());
}