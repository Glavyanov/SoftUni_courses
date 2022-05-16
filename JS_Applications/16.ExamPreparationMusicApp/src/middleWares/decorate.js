import {render} from '../../node_modules/lit-html/lit-html.js';
import { getUserData } from '../util.js';

const root = document.getElementById('main-content');

const renderCtx = (template) => {
    render(template,root);
}

export const decorateContext = (ctx, next) =>{
    ctx.user = getUserData;
    ctx.render = renderCtx;
    next();
}
