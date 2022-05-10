import { render, html} from '../node_modules/lit-html/lit-html.js';

document.getElementById('btnLoadTowns').addEventListener('click', getTowns);
const divRoot = document.getElementById('root');

function getTowns(e){
    e.preventDefault();
    let infoTowns = document.getElementById('towns').value;
    if (infoTowns && infoTowns.search(/^\s*$/)) {
        const towns = infoTowns.split(', ');
        
        const result = html`
        <ul>
            ${towns.filter(x => {
                if (x.search(/^\s*$/) && x) {
                    return x;
                }
            }).map(t => html`<li>${t}</li>`)}
        </ul>
        `;
        render(result,divRoot);
        document.getElementById('towns').value = '';
    }
    
}