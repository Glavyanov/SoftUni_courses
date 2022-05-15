import {html} from '../../node_modules/lit-html/lit-html.js';
import * as dataServices from '../api/data.js';
import { getUserData } from '../util.js';


export async function preload(ctx, next){
    const recipeId = ctx.params.id;
    ctx.render(html`<h4>Loading &hellip;</h4>`);
    const recipe = await dataServices.getById(recipeId);
    ctx.recipe = recipe;
    
    const user = getUserData();
    if (user && user.id == recipe._ownerId) {
        recipe._isOwner = true;
    }

    next();
}