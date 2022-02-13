window.addEventListener('load', solve);

function solve() {
    const genreInputElem = document.querySelector('#genre');
    const songNameInputElem = document.querySelector('#name');
    const authorInputElem = document.querySelector('#author');
    const dateInputElem = document.querySelector('#date');
    const addBtn = document.querySelector('#add-btn');
    const allHitsElem = document.querySelector('.all-hits-container');
    const savedHitsElem = document.querySelector('.saved-container');
    const likesElem = document.querySelector('.likes :first-child');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (genreInputElem.value && songNameInputElem.value &&
            authorInputElem.value && dateInputElem.value) {
            const divHitsInfo = document.createElement('div');
            divHitsInfo.setAttribute('class', 'hits-info');
            const imgElem = document.createElement('img');
            imgElem.setAttribute('src', './static/img/img.png');
            const h2GenreElem = document.createElement('h2');
            h2GenreElem.textContent = `Genre: ${genreInputElem.value}`;
            const h2NameElem = document.createElement('h2');
            h2NameElem.textContent = `Name: ${songNameInputElem.value}`;
            const h2AuthorElem = document.createElement('h2');
            h2AuthorElem.textContent = `Author: ${authorInputElem.value}`;
            const h3DateElem = document.createElement('h3');
            h3DateElem.textContent = `Date: ${dateInputElem.value}`;
            const saveBtn = document.createElement('button');
            saveBtn.setAttribute('class', 'save-btn');
            saveBtn.textContent = 'Save song';
            const likeBtn = document.createElement('button');
            likeBtn.setAttribute('class', 'like-btn');
            likeBtn.textContent = 'Like song';
            const deleteBtn = document.createElement('button');
            deleteBtn.setAttribute('class', 'delete-btn');
            deleteBtn.textContent = 'Delete';
            divHitsInfo.appendChild(imgElem);
            divHitsInfo.appendChild(h2GenreElem);
            divHitsInfo.appendChild(h2NameElem);
            divHitsInfo.appendChild(h2AuthorElem);
            divHitsInfo.appendChild(h3DateElem);
            divHitsInfo.appendChild(saveBtn);
            divHitsInfo.appendChild(likeBtn);
            divHitsInfo.appendChild(deleteBtn);
            allHitsElem.appendChild(divHitsInfo);
            genreInputElem.value = '';
            songNameInputElem.value = '';
            authorInputElem.value = '';
            dateInputElem.value = '';
            likeBtn.addEventListener('click', (e) => {
                let likes = Number(likesElem.textContent.split(': ').pop());
                likes++;
                likesElem.textContent = `Total Likes: ${likes}`;
                likeBtn.disabled = true;
            });
            saveBtn.addEventListener('click', (e) => {
                const divHitsSaved = document.createElement('div');
                divHitsSaved.setAttribute('class', 'hits-info');
                const imgSavedElem = document.createElement('img');
                imgSavedElem.setAttribute('src', './static/img/img.png');
                const h2GenreSavedElem = document.createElement('h2');
                h2GenreSavedElem.textContent = h2GenreElem.textContent;
                const h2NameSavedElem = document.createElement('h2');
                h2NameSavedElem.textContent = h2NameElem.textContent;
                const h2AuthorSavedElem = document.createElement('h2');
                h2AuthorSavedElem.textContent = h2AuthorElem.textContent;
                const h3DateSavedElem = document.createElement('h3');
                h3DateSavedElem.textContent = h3DateElem.textContent;
                const deleteSavedBtn = document.createElement('button');
                deleteSavedBtn.setAttribute('class', 'delete-btn');
                deleteSavedBtn.textContent = 'Delete';
                divHitsSaved.appendChild(imgSavedElem);
                divHitsSaved.appendChild(h2GenreSavedElem);
                divHitsSaved.appendChild(h2NameSavedElem);
                divHitsSaved.appendChild(h2AuthorSavedElem);
                divHitsSaved.appendChild(h3DateSavedElem);
                divHitsSaved.appendChild(deleteSavedBtn);
                savedHitsElem.appendChild(divHitsSaved);
                e.currentTarget.parentNode.remove();
                deleteSavedBtn.addEventListener('click', (e) => {
                    e.currentTarget.parentNode.remove();
                });
            });
            deleteBtn.addEventListener('click', (e) => {
                e.currentTarget.parentNode.remove();
            });
        }
    });
}