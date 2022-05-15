import page from '../node_modules/page/page.mjs';

import * as api from './api/data.js';
import { updateNav } from './middlewares/navbar.js';
import { preload } from './middlewares/preload.js';

import { decorateContext } from './middlewares/render.js';
import { catalogPage } from './views/catalog.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';

document.getElementById('logoutBtn').addEventListener('click', async function(){
    await api.logout();

    page.redirect('/');
});


page(updateNav);
page(decorateContext);
page('/', homePage);
page('/catalog', catalogPage);
page('/catalog/:id', preload, detailsPage);
page('/create', createPage);
page('/login', loginPage);
page('/register', registerPage);
page('/edit/:id', editPage);

page.start();

window.api = api;

