const url = 'http://localhost:3030/jsonstore/advanced/dropdown';

export async function getTowns(){
    const res = await fetch(url)
    return res.json();
}

export function postTown(text){
    fetch(url,{
        method: "POST",
        headers:{
            "content-type":"application/json"
        },
        body: JSON.stringify({text})
    })
}