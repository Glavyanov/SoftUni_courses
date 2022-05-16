import { logout } from '../api/data.js';

export async function logoutPage(ctx){
    await logout();
    ctx.page.redirect('/');
}