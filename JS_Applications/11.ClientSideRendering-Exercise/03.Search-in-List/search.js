import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const divTowns = document.getElementById('towns');
const searchBtn = document.querySelector('button');
searchBtn.addEventListener('click', search);

let content = html`
   <ul>
      ${towns.map(t => html`<li>${t}</li>`)}
   </ul>`;
render(content, divTowns);

function search() {
   const input = document.getElementById('searchText');
   let contentUpdate;
   const result = document.getElementById('result');
   if (input.value && input.value.search(/^\s*$/)) {
      contentUpdate = html`
      <ul>
         ${towns.map(t => t.toLowerCase().includes(input.value.toLowerCase()) ? html`<li class="active">${t}</li>` : html`<li>${t}</li>`)}
      </ul>`;
      const matches = towns.filter(t => t.toLowerCase().includes(input.value.toLowerCase())).length;
      matches ? result.textContent = `${matches} matches found` : null;
   }else {
      contentUpdate = html`
      <ul>
      ${towns.map(t => html`<li>${t}</li>`)}
      </ul>`;
      result.textContent = '';
   }
   render(contentUpdate, divTowns);
}
