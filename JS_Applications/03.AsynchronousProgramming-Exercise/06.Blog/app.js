function attachEvents() {
    const loadBtnElement = document.getElementById('btnLoadPosts');
    const viewBtnElement = document.getElementById('btnViewPost');

    loadBtnElement.addEventListener('click', getPosts);
    viewBtnElement.addEventListener('click', displayPosts);

}

attachEvents();

async function displayPosts() {
    try {

        const titleElement = document.getElementById('post-title');
        const bodyElement = document.getElementById('post-body');
        const selectedId = document.getElementById('posts').value;
        const commentsElement = document.getElementById('post-comments');

        titleElement.textContent = 'Loading...';
        bodyElement.textContent = '';

        commentsElement.replaceChildren();

        const [post, comments] = await Promise.all([
            getPostbyId(selectedId),
            getCommentbyId(selectedId)
        ]);

        titleElement.textContent = post.title;
        bodyElement.textContent = post.body;

        comments.forEach(c => {
            const liElement = document.createElement('li');
            liElement.setAttribute('id', c.id);
            liElement.textContent = c.text;
            commentsElement.appendChild(liElement);
        });

    } catch (error) {
        
        alert('Error');
    }
}

async function getPosts() {
    try {
        const url = 'http://localhost:3030/jsonstore/blog/posts';
        const res = await fetch(url);
        const data = await res.json();

        const selectMenuElement = document.getElementById('posts');
        selectMenuElement.replaceChildren();

        Object.values(data).forEach(element => {
            let optionElement = document.createElement('option');

            optionElement.textContent = element.title;
            optionElement.value = element.id;
            selectMenuElement.appendChild(optionElement);

        });

    } catch (error) {
        alert('Error');
    }
}

async function getPostbyId(wantedId) {
    try {
        const url = `http://localhost:3030/jsonstore/blog/posts/${wantedId}`;
        const res = await fetch(url);

        return await res.json();
    } catch (error) {
        alert('Error');
    }

}

async function getCommentbyId(wantedId) {
    try {
        const url = 'http://localhost:3030/jsonstore/blog/comments';
        const res = await fetch(url);
        const data = await res.json();

        return Object.values(data).filter(comment => comment.postId == wantedId);

    } catch (error) {
        alert('Error');
    }

}
