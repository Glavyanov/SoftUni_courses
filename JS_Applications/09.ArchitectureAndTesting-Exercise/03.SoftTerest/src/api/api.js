const host = 'http://localhost:3030';

async function request(method, url, data) {
    const options = {
        method,
        headers: {}
    };

    if (data !== undefined) {
        options.headers['content-type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
        const token = user.accessToken;
        options.headers['X-Authorization'] = token;
    }

    try {
        let responce = await fetch(host + url, options);
        if (responce.ok != true) {
            if (responce.status == 403) {
                localStorage.removeItem('user');
            }

            const error = await responce.json();
            throw new Error(error.message);
        }
        if (responce.status == 204) {
            return responce;
        } else {
            return responce.json();
        }

    } catch (err) {
        alert(err.message);
        throw err;
    }
}

const get = request.bind(null, 'get');
const post = request.bind(null, 'post');
const put = request.bind(null, 'put');
const del = request.bind(null, 'delete');

export {
    get,
    post,
    put,
    del as delete
}