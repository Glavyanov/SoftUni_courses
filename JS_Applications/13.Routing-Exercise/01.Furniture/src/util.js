export function getUserData(){
    return JSON.parse(sessionStorage.getItem('userData'));
}

export function setUserData(data){
    sessionStorage.setItem('userData', JSON.stringify(data));
}

export function clearUserData(){
    sessionStorage.removeItem('userData');
}

export function parseQueryString(query = ''){
    return Object.fromEntries(query
        .split('&')
        .map(kvp => kvp.split('=')));
}