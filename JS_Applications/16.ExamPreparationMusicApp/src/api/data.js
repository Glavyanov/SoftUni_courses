import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

const endpoints = {
    all: '/data/albums?sortBy=_createdOn%20desc&distinct=name',
    byId: (id) => `/data/albums/${id}`,
    edit: '/data/albums/',
    delete: '/data/albums/',
    create: '/data/albums',
    //myItems: (id) => `/data/albums/${id}`//
}

export async function getAllAlbums(){
    return api.get(endpoints.all);
}

export async function createAlbum(data){
    return api.post(endpoints.create, data);
}

export async function getById(id){
    return api.get(endpoints.byId(id));
}

export async function editItem(id, data){
    return api.put(endpoints.edit + id, data);
}

export async function deleteItem(id){
    return api.del(endpoints.delete + id);
}


// ///
// export async function getMyItems(userId){
//     return api.get(endpoints.myItems(userId));
// }