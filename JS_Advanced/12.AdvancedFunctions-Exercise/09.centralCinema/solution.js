function solve() {
    let onScreenBtn = document.querySelector('#container button');
    let nameElement = document.querySelector('#container [placeholder = "Name"]');
    let hallElement = document.querySelector('#container [placeholder = "Hall"]');
    let priceElement = document.querySelector('#container [placeholder = "Ticket Price"]');
    let onScreenElement = document.querySelector('#movies ul');
    let archiveUlElement = document.querySelector('#archive ul');
    let clearBtn = document.querySelector('#archive button:last-of-type');
    clearBtn.addEventListener('click',(e) => {
        let allUlLists = Array.from(e.currentTarget.parentNode.querySelectorAll('ul li'));
        allUlLists.forEach(x => {
            x.remove();
        })
    });
    
    onScreenBtn.addEventListener('click', (e) => {
        e.preventDefault();
        
        if (!isNaN(Number(priceElement.value)) && nameElement.value && hallElement.value &&
             priceElement.value.search(/^\s*$/) == -1 && nameElement.value.search(/^\s*$/) == -1 &&
             hallElement.value.search(/^\s*$/) == -1 ) {
            let liElement = document.createElement('li');
            let spanElement = document.createElement('span');
            spanElement.textContent = nameElement.value;
            liElement.appendChild(spanElement);
            let strongElement = document.createElement('strong');
            strongElement.textContent = `Hall: ${hallElement.value}`;
            liElement.appendChild(strongElement);
            let strongPriceElement = document.createElement('strong');
            strongPriceElement.textContent= Number(priceElement.value).toFixed(2);
            let inputElement = document.createElement('input');
            inputElement.setAttribute('placeholder','Tickets Sold');
            let buttonElement = document.createElement('button');
            buttonElement.textContent = 'Archive';
            let divElement = document.createElement('div');
            divElement.appendChild(strongPriceElement);
            divElement.appendChild(inputElement);
            divElement.appendChild(buttonElement);
            liElement.appendChild(divElement);
            onScreenElement.appendChild(liElement);
            priceElement.value = '';
            hallElement.value = '';
            nameElement.value = '';
            buttonElement.addEventListener('click', (e) => {
                let ticketPrice = e.currentTarget.previousSibling.value;
                if (!isNaN(Number(ticketPrice)) && ticketPrice.search(/^\s*$/) == -1) {
                    let spanArchiveEl = e.currentTarget.parentNode.parentNode.firstChild;
                    let strongArchiveEl = document.createElement('strong');
                    strongArchiveEl.textContent = `Total amount: ${(Number(e.currentTarget.parentNode.firstChild.textContent) * Number(ticketPrice)).toFixed(2)}`
                    let buttonDelete = document.createElement('button');
                    buttonDelete.textContent = 'Delete';
                    let liArchiveEl = document.createElement('li');
                    liArchiveEl.appendChild(spanArchiveEl);
                    liArchiveEl.appendChild(strongArchiveEl);
                    liArchiveEl.appendChild(buttonDelete);
                    buttonDelete.addEventListener('click', (ev) => {
                        ev.currentTarget.parentNode.remove();
                    });
                    archiveUlElement.appendChild(liArchiveEl);
                    e.currentTarget.parentNode.parentNode.remove();
                }
                
            });
        }
        
    });
    
}