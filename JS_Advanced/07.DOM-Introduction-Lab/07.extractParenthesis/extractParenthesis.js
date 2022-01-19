function extract(content) {
    text = document.getElementById(content).innerHTML;
    
    let arr = text.match(/\(.*?\)/gim);
    for (const match of arr) {
        text = text.replace(match, '');
    }
    document.getElementById(content).innerHTML = text;

    return arr.map(x => x.replace('(','').replace(')','')).join('; ');
}