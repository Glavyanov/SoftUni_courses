function attachEvents() {

    document.getElementById('submit').addEventListener('click', submitMessage);
    document.getElementById('refresh').addEventListener('click', getAllMessages);

}

attachEvents();

async function getAllMessages() {
    const url = 'http://localhost:3030/jsonstore/messenger';
    try {
        const res = await fetch(url);
        const data = await res.json();
        const textAreaElement = document.getElementById('messages');
        const result = [];
        Object.values(data).forEach(m => {
            result.push(`${m.author}: ${m.content}`);
        });
        textAreaElement.textContent = result.join('\n');
    } catch (error) {
        alert('Server Error');
        return;
    }
}

async function submitMessage(e) {
    const author = e.currentTarget.parentElement.querySelector('[name="author"]').value;
    const content = e.currentTarget.parentElement.querySelector('[name="content"]').value;
    const url = 'http://localhost:3030/jsonstore/messenger';
    document.querySelector('[name="author"]').value = '';
    document.querySelector('[name="content"]').value = '';

    if (!author || !content || !author.search(/^\s*$/) || !content.search(/^\s*$/)) {
        
        alert('Name and/or Message are empty');

    } else {
        
        try {
            await fetch(url,{
                method: 'POST',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({
                    author,
                    content,
                })
            });
            
        } catch (error) {
            alert('Server Error');
        }
    }
}