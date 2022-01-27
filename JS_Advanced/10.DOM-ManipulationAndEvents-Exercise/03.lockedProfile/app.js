function lockedProfile() {
    let divElements = Array.from(document.querySelectorAll('#main div.profile'));
    divElements.forEach(x => {
        let currentBtn = x.querySelector('button');

        currentBtn.addEventListener('click', (e) => {
            let currentRadioCheck = e.target.parentElement.querySelector('[value="unlock"]'); // .querySelector('input[type="radio"]:checked');
            let targetBtn = e.target.parentElement.querySelector('button');
            let divHidden = e.target.parentElement.querySelector('[id*="HiddenFields"]');
            if (currentRadioCheck.checked) {
                if (targetBtn.textContent == 'Show more') {
                    divHidden.style.display = 'block';
                    targetBtn.textContent = 'Hide it';
                } else {
                    divHidden.style.display = 'none';
                    targetBtn.textContent = 'Show more';
                }
            }
        });
    });
}