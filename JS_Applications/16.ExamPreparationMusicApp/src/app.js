import page from '../node_modules/page/page.mjs';
import { homePage } from './pages/home.js';
import { catalogPage } from './pages/catalog.js';
import { decorateContext } from './middleWares/decorate.js';
import { updateNav } from './middleWares/updateUserNav.js';
import { loginPage } from './pages/login.js';
import { logoutPage } from './pages/logout.js';
import { registerPage } from './pages/register.js';
import { createPage } from './pages/create.js';
import { detailsPage } from './pages/details.js';
import { editPage } from './pages/edit.js';
import { removePage } from './pages/remove.js';

page(decorateContext);
page(updateNav);
page('/', homePage);
page('/catalog', catalogPage);
page('/login', loginPage);
page('/logout', logoutPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/remove/:id', removePage);

page.start();