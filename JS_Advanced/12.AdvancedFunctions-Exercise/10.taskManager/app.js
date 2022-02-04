function solve() {
    let inputTaskEl = document.querySelector('.wrapper section:first-of-type #task');
    let textDescriptionEl = document.querySelector('.wrapper section:first-of-type #description');
    let dateEl = document.querySelector('.wrapper section:first-of-type #date');
    let addBtn = document.querySelector('#add');
    let openSection = document.querySelector('.wrapper section:nth-of-type(2) div:nth-of-type(2)');
    let inProgressSection = document.querySelector('.wrapper section:nth-of-type(3) #in-progress');
    let completeSection = document.querySelector('.wrapper section:nth-of-type(4) div:nth-of-type(2)');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (inputTaskEl.value && textDescriptionEl.value && dateEl.value &&
            inputTaskEl.value.search(/^\s*$/) == -1 && textDescriptionEl.value.search(/^\s*$/) == -1 &&
            dateEl.value.search(/^\s*$/) == -1) {
            let articleEl = document.createElement('article');
            let h3El = document.createElement('h3');
            h3El.textContent = inputTaskEl.value;
            let paragraphDescriptEl = document.createElement('p');
            paragraphDescriptEl.textContent = `Description: ${textDescriptionEl.value}`;
            let paragraphDateEl = document.createElement('p');
            paragraphDateEl.textContent = `Due Date: ${dateEl.value}`;
            let divFlexEl = document.createElement('div');
            divFlexEl.setAttribute('class', 'flex');
            let btnGreen = document.createElement('button');
            btnGreen.setAttribute('class', 'green');
            btnGreen.textContent = 'Start';
            let btnRed = document.createElement('button');
            btnRed.setAttribute('class', 'red');
            btnRed.textContent = 'Delete';
            divFlexEl.appendChild(btnGreen);
            divFlexEl.appendChild(btnRed);
            articleEl.appendChild(h3El);
            articleEl.appendChild(paragraphDescriptEl);
            articleEl.appendChild(paragraphDateEl);
            articleEl.appendChild(divFlexEl);
            openSection.appendChild(articleEl);
            inputTaskEl.value = '';
            textDescriptionEl.value = '';
            dateEl.value = '';

            btnGreen.addEventListener('click', () => {
                inProgressSection.appendChild(articleEl);
                btnGreen.classList.replace('green', 'red');
                btnGreen.textContent = 'Delete';
                btnRed.classList.replace('red', 'orange');
                btnRed.textContent = 'Finish';
                btnRed
                btnGreen.addEventListener('click', (e) => {
                    e.currentTarget.parentNode.parentNode.remove();
                });
                btnRed.addEventListener('click', () => {
                    completeSection.appendChild(articleEl);
                    articleEl.getElementsByClassName('flex')[0].remove();
                });
            });
            btnRed.addEventListener('click', () => {
                openSection.getElementsByTagName('article')[0].remove();

            });
        }
    });
}