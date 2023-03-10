const baseUrl = 'http://localhost:3005/api/items';

export const getAll = async () =>{
    const responce = await fetch(baseUrl);
    const result = await  responce.json();

    return result.items;
};