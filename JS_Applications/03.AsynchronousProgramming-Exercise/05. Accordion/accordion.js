async function solution() {
    const mainElement = document.getElementById('main');
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    let data;
    try {
        const res = await fetch(url);
        data = await res.json();
    } catch (error) {
        alert('Error');
        return;
    }


    data.forEach(art => {
        const divAccordion = document.createElement('div');
        divAccordion.className = 'accordion';

        const divHead = document.createElement('div');
        divHead.className = 'head';

        const spanHead = document.createElement('span');
        spanHead.textContent = art.title;

        let button = document.createElement('button');
        button.className = 'button';
        button.textContent = 'More';
        button.setAttribute('id', art._id);

        const divExtra = document.createElement('div');
        divExtra.className = 'extra';

        const paragraphExtra = document.createElement('p');

        divExtra.appendChild(paragraphExtra);
        divHead.appendChild(spanHead);
        divHead.appendChild(button);
        divAccordion.appendChild(divHead);
        divAccordion.appendChild(divExtra);
        mainElement.appendChild(divAccordion);

        button.addEventListener('click', toggle);
    })
}
solution();

async function toggle(ev) {

    if (ev.target.textContent == 'More') {
        ev.target.textContent = 'Less';
        const url = `http://localhost:3030/jsonstore/advanced/articles/details/${ev.currentTarget.id}`;

        const res = await fetch(url);
        const data = await res.json();

        const p = ev.target.parentElement.nextSibling.firstChild;
        p.textContent = data.content;
        ev.target.parentElement.nextSibling.style.display = 'block';

    } else {
        ev.target.textContent = 'More';
        ev.target.parentElement.nextSibling.style.display = 'none';

    }

}