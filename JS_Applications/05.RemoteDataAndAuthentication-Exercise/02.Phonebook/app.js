function attachEvents() {
    const url = `http://localhost:3030/jsonstore/phonebook`;

    const ul = document.getElementById('phonebook');
    const loadBtn = document.getElementById('btnLoad');
    const createBtn = document.getElementById('btnCreate');

    const person = document.getElementById('person');
    const phone = document.getElementById('phone');

    loadBtn.addEventListener('click', onClickLoad);
    createBtn.addEventListener('click', onClickCreate);
    
    async function onClickLoad() {
        ul.innerHTML = '';
        loadBtn.disabled = true;
        try {
            const response = await fetch(url);
            const data = await response.json();

            Object.values(data).forEach(x => {
                const { person, phone, _id } = x;

                const li = createElement('li', `${person}: ${phone}`, ul);
                li.setAttribute('id', _id);
                createBtn.textContent = 'Create';

                const deleteBtn = createElement('button', 'Delete', li);
                deleteBtn.setAttribute('id', 'btnDelete');
                deleteBtn.addEventListener('click', onClickDelete);
            })
        } catch (error) {
            alert('Server Error');
            loadBtn.disabled = false;

        }
        loadBtn.disabled = false;

    }
    async function onClickDelete(ev) {
        try {
            const id = ev.target.parentNode.id;
            await fetch(`${url}/${id}`, {
                method: 'DELETE',
            });
        } catch (error) {
            alert('Server Error');
            return;
        }
        ev.target.parentNode.remove();

    }
    async function onClickCreate() {

        if (person.value !== '' && phone.value !== '' && person.value.search(/^\s*$/) == -1 && person.value.search(/^\s*$/) == -1) {
            createBtn.textContent = 'Loading...';
            try {
                await fetch(url, {
                    method: 'POST',
                    headers: { 'content-type': 'application/json' },
                    body: JSON.stringify({ person: person.value, phone: phone.value })
                });
                loadBtn.click();
            } catch (error) {
                alert('Server Error');
                createBtn.textContent = 'Create';
            }

            person.value = '';
            phone.value = '';

        } else {
            alert('Person and/or Phone are empty');
        }

    }

    function createElement(type, text, appender) {
        const result = document.createElement(type);

        result.textContent = text;

        appender.appendChild(result);

        return result;

    }

}
attachEvents();
