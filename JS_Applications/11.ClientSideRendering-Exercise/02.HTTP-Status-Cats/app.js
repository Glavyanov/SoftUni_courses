import { render } from '../node_modules/lit-html/lit-html.js';
import { cats } from './catSeeder.js';
import { cardsTemplate } from './cards.js';

const sectionAllCats = document.getElementById('allCats');
const content = cardsTemplate(cats);

render(content, sectionAllCats);

