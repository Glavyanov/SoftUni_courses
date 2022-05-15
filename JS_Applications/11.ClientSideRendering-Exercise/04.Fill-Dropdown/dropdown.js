import { render } from '../node_modules/lit-html/lit-html.js';
import { getTowns, postTown } from './api.js';
import { renderTowns } from './towns.js';

const menu = document.getElementById('menu');
document.querySelector('form').addEventListener('submit', addItem);
const input = document.getElementById('itemText');

const towns = await getTowns();
const content = renderTowns(Object.values(towns));

render(content, menu);

async function addItem(e) {
    e.preventDefault();
    const addElement = document.querySelector('[value="Add"]');

    if (input.value && input.value.search(/^\s*$/)) {
        addElement.disabled = true;
        addElement.value = 'Loading...';
        const [_,allTowns] = await Promise.all([
             postTown(input.value),
             await getTowns()
        ]);
        const postContent = renderTowns(Object.values(allTowns));
        render(postContent, menu);
        input.value = '';
        addElement.disabled = false;
        addElement.value = 'Add';
    }
}