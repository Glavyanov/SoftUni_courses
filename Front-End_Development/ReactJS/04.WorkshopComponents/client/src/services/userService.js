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

export const create = async (userData) => {
    const {country, city, street, streetNumber, ...data} = userData;
    data.address = {
        country,
        city,
        street,
        streetNumber
    }
    const responce = await fetch(baseUrl,{
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    })

    const result = await responce.json();

    return result.user;
};

export const remove = async (userId) => {
    const responce = await fetch(`${baseUrl}/${userId}`, {
        method: 'DELETE'
    });

    const result = await responce.json();

    return result;
};

export const update = async (userId, userData) => {

    const {country, city, street, streetNumber, ...data} = userData;
    data.address = {
        country,
        city,
        street,
        streetNumber
    };

    const responce = await fetch(`${baseUrl}/${userId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    const result = await responce.json();

    return result.user;
};