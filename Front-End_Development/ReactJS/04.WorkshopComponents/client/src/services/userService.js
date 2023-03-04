const baseUrl = 'http://localhost:3005/api/users';

export const getAll = async () =>{
    const responce = await fetch(baseUrl);
    const result = await  responce.json();

    return result.users;
};

export const getOne = async (userId) =>{
    const responce = await fetch(`${baseUrl}/${userId}`);
    const result = await  responce.json();

    return result.user;
};