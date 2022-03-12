(function () {
    const url = 'http://localhost:3030/jsonstore/collections/books';
    const tbodyElement = document.querySelector('table tbody');
    const submitBtn = document.querySelector('#submit');
    const loadBtn = document.getElementById('loadBooks');
    const tableElement = document.querySelector('table');
    const formElement = document.querySelector('body form');
    
    tbodyElement.replaceChildren();

    loadBtn.addEventListener('click', loadAllBooks);
    submitBtn.addEventListener('click', operationsBook);
    tableElement.addEventListener('click', editAndDeleteBook);

    let id;

    async function loadAllBooks() {
        try {
            loadBtn.textContent = 'Loading...';
            loadBtn.disabled = true;
            tbodyElement.replaceChildren();
            const res = await fetch(url);
            const data = await res.json();
            Object.entries(data).forEach(info => {
                let tableRowElement = document.createElement('tr');
                tableRowElement.innerHTML = `
                <td>${info[1].title}</td>
                <td>${info[1].author}</td>
                <td>
                    <button>Edit</button>
                    <button>Delete</button>
                </td>
            `;
                tableRowElement.setAttribute('id', info[0]);
                tbodyElement.appendChild(tableRowElement);
            });
        } catch (error) {
            alert('Server Error');
        }
        loadBtn.textContent = 'LOAD ALL BOOKS';
        loadBtn.disabled = false;
        formElement.querySelector('h3').textContent = 'FORM';
        submitBtn.textContent = 'Submit';
        formElement.reset();

    }

    async function operationsBook(e) {
        e.preventDefault();
        e.target.disabled = true;
        let form = new FormData(formElement);
        let author = form.get('author');
        let title = form.get('title');

        if (!author || !title || !author.search(/^\s*$/) || !title.search(/^\s*$/)) {
            alert('Title and Author must be filled');
            e.target.disabled = false;
            return;
        }
        author = escapeHtml(author);
        title = escapeHtml(title);
        if (submitBtn.textContent == 'Submit') {
            try {
                await Promise.all([
                    submitBook(author, title),
                    loadAllBooks()
                ]);

            } catch (error) {
                alert('Server Error');
            }
        } else if (submitBtn.textContent == 'Save') {
            try {
                await Promise.all([
                    editBook(id, author, title),
                    loadAllBooks()
                ]);

            } catch (error) {
                alert('Server Error');
            }

            formElement.querySelector('h3').textContent = 'FORM';
            submitBtn.textContent = 'Submit';
        }

        e.target.disabled = false;
        formElement.reset();
    }

    async function editAndDeleteBook(e) {
        e.target.disabled = true;
        id = e.target.parentElement.parentElement.id;

        if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Edit') {
            formElement.querySelector('h3').textContent = 'EditFORM';
            submitBtn.textContent = 'Save';

            formElement.querySelector('[name="title"]').value = e.target.parentElement.parentElement.children[0].textContent;
            formElement.querySelector('[name="author"]').value = e.target.parentElement.parentElement.children[1].textContent;

        } else if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Delete') {
            loadBtn.textContent = 'Loading...';
            const res = await fetch(`${url}/${id}`, {
                method: "DELETE"
            });
            if (res.status != 200) {
                alert('Error');
            } else {
                e.target.parentElement.parentElement.remove();
                formElement.querySelector('h3').textContent = 'FORM';
                submitBtn.textContent = 'Submit';
                formElement.reset();
            }
        }
        loadBtn.textContent = 'LOAD ALL BOOKS';
        e.target.disabled = false;
    }

    async function editBook(id, author, title) {

        const res = await fetch(`${url}/${id}`, {
            method: "PUT",
            headers: {
                "content-type": "aplication/json"
            },
            body: JSON.stringify({ author, title })
        });
        if (res.status != 200) {
            alert('Error');
        }
    }

    async function submitBook(author, title) {
        const res = await fetch(url, {
            method: "POST",
            headers: {
                "content-type": "aplication/json"
            },
            body: JSON.stringify({ author, title })
        });
        if (res.status != 200) {
            alert('Error');
        }
    }

    function escapeHtml(value) {
        return value
            .toString()
            .replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }

})();
