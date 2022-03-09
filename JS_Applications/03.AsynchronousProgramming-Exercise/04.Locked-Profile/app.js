function lockedProfile() {
    const mainProfilesElement = document.querySelector('#main');
    let divProfileElement = document.querySelector('.profile');
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    (async function () {
        try {
            const res = await fetch(url);
            const data = await res.json();

            Object.values(data).forEach((user, i) => {
                
                let currentDiv = divProfileElement.cloneNode(true);
                currentDiv.innerHTML = `
                <img src="./iconProfile2.png" class="userIcon" />
				<label>Lock</label>
				<input type="radio" name="user${i + 1}Locked" value="lock" checked>
				<label>Unlock</label>
				<input type="radio" name="user${i + 1}Locked" value="unlock"><br>
				<hr>
				<label>Username</label>
				<input type="text" name="user${i + 1}Username" value="${user.username}" disabled readonly />
				<div class="hiddenInfo">
					<hr>
					<label>Email:</label>
					<input type="email" name="user${i + 1}Email" value="${user.email}" disabled readonly />
					<label>Age:</label>
					<input type="email" name="user${i + 1}Age" value="${user.age}" disabled readonly />
				</div>
				
				<button>Show more</button>
                `;

                if (i == 0) {
                    mainProfilesElement.replaceChildren();
                    mainProfilesElement.appendChild(currentDiv);

                } else {
                    mainProfilesElement.appendChild(currentDiv);
                }

                currentDiv.querySelector('button').addEventListener('click', (e) => {
                    const currentRadioCheck = e.currentTarget.parentElement.querySelector('[value="unlock"]');
                    const divHidden = e.currentTarget.parentElement.querySelector('.hiddenInfo');

                    if (currentRadioCheck.checked) {
                        if (e.currentTarget.textContent == 'Show more') {
                            divHidden.querySelectorAll('input , label').forEach(c => c.style.display = 'block');
                            e.currentTarget.textContent = 'Hide it';
                        } else {
                            divHidden.querySelectorAll('input , label').forEach(c => c.style.display = 'none');
                            e.currentTarget.textContent = 'Show more';
                        }
                    }
                })

            });
        } catch (error) {
            alert('Error')
            return;
        }

    })();
}