import { html} from '../node_modules/lit-html/lit-html.js';

export function renderTowns(data){
    return html`
    ${data.map(t => html`<option value=${t._id}>${t.text}</option>`)}
    `;

}