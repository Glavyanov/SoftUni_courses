import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const endpoints = {
    all: '/data/recipes',
    recent: '/data/recipes?select=_id%2Cname%2Cimg&sortBy=_createdOn%20desc&pageSize=3',
    byId: '/data/recipes/',
    edit: '/data/catalog/',
    delete: '/data/catalog/',
    create: '/data/catalog',
    myItems: (userId) => `/data/catalog?where=_ownerId%3D%22${userId}%22`
}

export async function getAll(){
    return api.get(endpoints.all);
}

export async function getRecent(){
    return api.get(endpoints.recent);
}

export async function getById(id){
    return api.get(endpoints.byId + id);
}



export async function getMyItems(userId){
    return api.get(endpoints.myItems(userId));
}

export async function createItem(data){
    return api.post(endpoints.create, data);
}

export async function editItem(id, data){
    return api.put(endpoints.edit + id, data);
}

export async function deleteItem(id){
    return api.del(endpoints.delete + id);
}
