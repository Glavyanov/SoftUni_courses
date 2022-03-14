const accessToken = localStorage.getItem('accessToken');
const fieldSetElement = document.querySelector('#home-view #main');
const sectionMainElement = document.querySelector('main #home-view');
const addBtn = document.querySelector('#addForm .add');
const logoutBtn = document.querySelector('nav #logout');
const urlLogout = 'http://localhost:3030/users/logout';
const urlLoad = 'http://localhost:3030/data/catches';
const home = document.querySelector('nav #home');
const loadBtn = document.querySelector('#home-view aside .load');

if (fieldSetElement) {
    fieldSetElement.remove();

}
if (accessToken && addBtn) {
    addBtn.disabled = false;
    addBtn.addEventListener('click', createContent);
}

displayUser();
hideLogoutBtn();

logoutBtn.addEventListener('click', logout);
loadBtn ? loadBtn.addEventListener('click', loadContent) : null;

async function logout() {
    logoutBtn.disabled = false;
    try {
        const res = await fetch(urlLogout, {
            method: "GET",
            headers: {
                "X-Authorization": accessToken
            }
        });
        if (res.status == 204) {
            localStorage.clear();
            home.click();
        }

        logoutBtn.disabled = true;

    } catch (error) {
        logoutBtn.disabled = true;
        alert('Unsuccessful Logout');
    }

}

async function loadContent() {
    loadBtn.disabled = true;
    loadBtn.textContent = 'Loading...';
    const currFieldSetElement = document.querySelector('#home-view #main');

    try {
        const res = await fetch(urlLoad);
        const data = await res.json();

        if (data) {
            currFieldSetElement ? currFieldSetElement.remove() : null;

            const fieldset = document.createElement('fieldset');
            fieldset.setAttribute('id', 'main');

            const legend = document.createElement('legend');
            legend.textContent = 'Catches';

            const divCatches = document.createElement('div');
            divCatches.setAttribute('id', 'catches');

            fieldset.appendChild(legend);
            fieldset.appendChild(divCatches);

            data.forEach(c => {
                const divCatch = document.createElement('div');
                divCatch.setAttribute('class', 'catch');
                divCatch.innerHTML = `
                <label>Angler</label>
                <input type="text" class="angler" value="${c.angler}">
                <label>Weight</label>
                <input type="text" class="weight" value="${c.weight}">
                <label>Species</label>
                <input type="text" class="species" value="${c.species}">
                <label>Location</label>
                <input type="text" class="location" value="${c.location}">
                <label>Bait</label>
                <input type="text" class="bait" value="${c.bait}">
                <label>Capture Time</label>
                <input type="number" class="captureTime" value="${c.captureTime}">
                <button class="update" data-id="${c._id}" disabled >Update</button>
                <button class="delete" data-id="${c._id}" disabled >Delete</button>`;
                divCatches.appendChild(divCatch);
                if (c._ownerId == localStorage.getItem('_id')) {
                    const updateBtn = divCatch.querySelector('.update');
                    updateBtn.disabled = false;
                    updateBtn.addEventListener('click', updateContent);
                    const deleteBtn = divCatch.querySelector('.delete');
                    deleteBtn.disabled = false;
                    deleteBtn.addEventListener('click', deleteContent);
                }
            })
            fieldset.appendChild(divCatches);
            sectionMainElement.prepend(fieldset);
        }

    } catch (error) {
        alert('Error');
        loadBtn.textContent = 'Load';
        loadBtn.disabled = false;
        return;
    }

    loadBtn.textContent = 'Load';
    loadBtn.disabled = false;
}

async function createContent(e) {
    e.preventDefault();
    addBtn.disabled = true;
    addBtn.textContent = 'Loading...';
    const formElement = document.querySelector('#addForm');
    const form = new FormData(formElement);
    const angler = form.get('angler');
    const weight = form.get('weight');
    const species = form.get('species');
    const location = form.get('location');
    const bait = form.get('bait');
    const captureTime = form.get('captureTime');
    if (!angler || !weight || !species || !location || !bait || !captureTime
        || !angler.search(/^\s*$/) || !weight.search(/^\s*$/) || !species.search(/^\s*$/) || !location.search(/^\s*$/)
        || !bait.search(/^\s*$/) || !captureTime.search(/^\s*$/)) {
        alert('Fields cannot be empty');
        addBtn.disabled = false;
        addBtn.textContent = 'Add';

        return;
    }
    try {
        const res = await fetch(urlLoad, {
            method: "POST",
            headers: {
                "content-type": "application/json",
                "X-Authorization": accessToken
            },
            body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
        });
    } catch (error) {
        alert('Error');
    }
    formElement.reset();
    addBtn.textContent = 'Add';
    addBtn.disabled = false;

}

async function deleteContent(e) {
    e.target.disabled = true;
    const id = e.target.dataset.id;

    const res = await fetch(`${urlLoad}/${id}`, {
        method: "DELETE",
        headers: {
            "X-Authorization": accessToken
        }
    });

    if (res.status != 200) {
        alert('Error');

    } else {
        e.target.parentElement.remove();

    }

    e.target.disabled = false;
}

async function updateContent(e) {
    if (e.target.textContent == 'Update') {
        e.target.disabled = true;
        e.target.textContent = 'Loading...';

        const id = e.target.dataset.id;

        const angler = e.target.parentElement.querySelector('.angler').value;
        const weight = e.target.parentElement.querySelector('.weight').value;
        const species = e.target.parentElement.querySelector('.species').value;
        const location = e.target.parentElement.querySelector('.location').value;
        const bait = e.target.parentElement.querySelector('.bait').value;
        const captureTime = e.target.parentElement.querySelector('.captureTime').value;

        if (!angler || !weight || !species || !location || !bait || !captureTime
            || !angler.search(/^\s*$/) || !weight.search(/^\s*$/) || !species.search(/^\s*$/) || !location.search(/^\s*$/)
            || !bait.search(/^\s*$/) || !captureTime.search(/^\s*$/)) {
            alert('Fields cannot be empty');
            e.target.disabled = false;
            e.target.textContent = 'Update';
            return;
        }

        try {
            const res = await fetch(`${urlLoad}/${id}`, {
                method: "PUT",
                headers: {
                    "content-type": "application/json",
                    "X-Authorization": accessToken
                },
                body: JSON.stringify({ angler, weight, species, location, bait, captureTime })

            })

        } catch (error) {
            alert('Error');
        }
        e.target.disabled = false;
        e.target.textContent = 'Update';

    }

}

export function hideLogoutBtn() {
    if (!accessToken) {
        document.querySelector('nav #logout').style.display = 'none';
    }
}

export function displayUser() {
    if (accessToken) {
        document.querySelector('nav .email span').textContent = localStorage.getItem('email');
    }
}

export function setUser(data, message, currentBtn, currentFormElement) {
    localStorage.setItem('_id', data._id);
    localStorage.setItem('username', data.username);
    localStorage.setItem('accessToken', data.accessToken);
    localStorage.setItem('email', data.email);

    alert(message);
    currentFormElement.reset();

    document.querySelector('nav .email span').textContent = localStorage.getItem('email');
    currentBtn.disabled = false;
    document.querySelector('nav #home').click();
}