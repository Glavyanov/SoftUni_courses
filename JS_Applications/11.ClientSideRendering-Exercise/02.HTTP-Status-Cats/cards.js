import { html } from '../node_modules/lit-html/lit-html.js'

export function cardsTemplate(data) {
    return html`
    <ul @mouseover = ${toggle}>
        ${data.map(c => html`
        <li>
            <img src="./images/${c.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn">Show status code</button>
                <div class="status" style="display: none" id=${c.id}>
                    <h4>Status Code: ${c.statusCode}</h4>
                    <p>${c.statusMessage}</p>
                </div>
            </div>
        </li>`)}
    </ul>
    `;
    
}

function toggle(e){

    if (e.target.tagName == 'BUTTON') {
        if (e.target.textContent  == 'Show status code') {
            e.target.textContent = 'Hide status code';
            e.target.parentElement.querySelector('.status').style.display = 'block';
        }else{
            e.target.textContent = 'Show status code';
            e.target.parentElement.querySelector('.status').style.display = 'none';
        }
    }
}

