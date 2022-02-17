window.addEventListener('load', solve);

function solve() {
    const selectTypeElem = document.querySelector('#type-product');
    const descriptionElem = document.querySelector('#description');
    const clientNameElem = document.querySelector('#client-name');
    const clientPhoneElem = document.querySelector('#client-phone');
    const submitBtnElem = document.querySelector('[type="submit"]');
    const clearBtnElem = document.querySelector('[class="clear-btn"]');
    const receivedOrdersElem = document.querySelector('#received-orders');
    const completedOrdersElem = document.querySelector('#completed-orders');

    submitBtnElem.addEventListener('click', (e) => {
        e.preventDefault();
        if (descriptionElem.value && clientNameElem.value && clientPhoneElem.value) {

            let divContainer = document.createElement('div');
            divContainer.setAttribute('class', 'container');

            let h2Elem = document.createElement('h2');
            h2Elem.textContent = `Product type for repair: ${selectTypeElem.value}`;

            let h3Elem = document.createElement('h3');
            h3Elem.textContent = `Client information: ${clientNameElem.value}, ${clientPhoneElem.value}`;

            let h4Elem = document.createElement('h4');
            h4Elem.textContent = `Description of the problem: ${descriptionElem.value}`;

            let buttonStartElem = document.createElement('button');
            buttonStartElem.setAttribute('class', 'start-btn');
            buttonStartElem.textContent = 'Start repair';

            let buttonFinishElem = document.createElement('button');
            buttonFinishElem.setAttribute('class', 'finish-btn');
            buttonFinishElem.textContent = 'Finish repair';
            buttonFinishElem.disabled = true;

            divContainer.appendChild(h2Elem);
            divContainer.appendChild(h3Elem);
            divContainer.appendChild(h4Elem);
            divContainer.appendChild(buttonStartElem);
            divContainer.appendChild(buttonFinishElem);
            receivedOrdersElem.appendChild(divContainer);

            descriptionElem.value = '';
            clientNameElem.value = '';
            clientPhoneElem.value = '';

            buttonStartElem.addEventListener('click', (e) => {
                e.currentTarget.disabled = true;
                e.currentTarget.nextSibling.disabled = false;
            });

            buttonFinishElem.addEventListener('click', (e) => {
                if (!e.currentTarget.disabled) {
                    let divContainerCompleted = document.createElement('div');
                    divContainerCompleted.setAttribute('class', 'container');
                    
                    let h2CompletedElem = document.createElement('h2');
                    h2CompletedElem.textContent = h2Elem.textContent;

                    let h3CompletedElem = document.createElement('h3');
                    h3CompletedElem.textContent = h3Elem.textContent;

                    let h4CompletedElem = document.createElement('h4');
                    h4CompletedElem.textContent = h4Elem.textContent;

                    divContainerCompleted.appendChild(h2CompletedElem);
                    divContainerCompleted.appendChild(h3CompletedElem);
                    divContainerCompleted.appendChild(h4CompletedElem);
                    
                    completedOrdersElem.appendChild(divContainerCompleted);
                    e.currentTarget.parentNode.remove();
                    clearBtnElem.addEventListener('click', (e) => {
                        Array.from(e.currentTarget.parentNode.querySelectorAll('div')).forEach(x => x.remove());
                    });
                }
            });
        }
    });
}