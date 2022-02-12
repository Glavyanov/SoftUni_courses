window.addEventListener('load', solve);

function solve() {
    const addBtn = document.querySelector('#add');
    addBtn.type = 'button';
    const modelElem = document.querySelector('#model');
    const yearElem = document.querySelector('#year');
    const descriptionElem = document.querySelector('#description');
    const priceElem = document.querySelector('#price');
    const furnitureListElem = document.querySelector('#furniture-list');
    const totalPriceElem = document.querySelector('.total-price');

    addBtn.addEventListener('click', (e) => {
        if (modelElem.value && descriptionElem.value && !isNaN(Number(yearElem.value)) && !isNaN(Number(priceElem.value))
            && modelElem.value.search(/^\s*$/) && descriptionElem.value.search(/^\s*$/)
            && Number(yearElem.value) >= 0 && Number(priceElem.value)>= 0) {
            const trInfoElem = document.createElement('tr');
            trInfoElem.setAttribute('class', 'info');
            const tdmodelElem = document.createElement('td');
            tdmodelElem.textContent = modelElem.value;
            const tdpriceElem = document.createElement('td');
            tdpriceElem.textContent = (Number(priceElem.value)).toFixed(2);
            trInfoElem.appendChild(tdmodelElem);
            trInfoElem.appendChild(tdpriceElem);
            const tdBtnsElem = document.createElement('td');
            const btnMoreElem = document.createElement('button');
            btnMoreElem.setAttribute('class', 'moreBtn');
            btnMoreElem.textContent = 'More Info';
            const btnBuyElem = document.createElement('button');
            btnBuyElem.setAttribute('class', 'buyBtn');
            btnBuyElem.textContent = 'Buy it';
            tdBtnsElem.appendChild(btnMoreElem);
            tdBtnsElem.appendChild(btnBuyElem);
            trInfoElem.appendChild(tdBtnsElem);
            const trHideElem = document.createElement('tr');
            trHideElem.setAttribute('class', 'hide');
            trHideElem.style.display = 'none';
            const tdYearElem = document.createElement('td');
            tdYearElem.textContent = `Year: ${yearElem.value}`;
            const tdDescriptionElem = document.createElement('td');
            tdDescriptionElem.setAttribute('colspan', 3);
            tdDescriptionElem.textContent = `Description: ${descriptionElem.value}`;
            trHideElem.appendChild(tdYearElem);
            trHideElem.appendChild(tdDescriptionElem);
            furnitureListElem.appendChild(trInfoElem);
            furnitureListElem.appendChild(trHideElem);
            modelElem.value = '';
            yearElem.value = '';
            descriptionElem.value = '';
            priceElem.value = '';
            btnMoreElem.addEventListener('click', (e) => {
                btnMoreElem.textContent == 'Less Info'? btnMoreElem.textContent = 'More info': btnMoreElem.textContent = 'Less Info';
                btnMoreElem.textContent == 'Less Info'? trHideElem.style.display = 'contents': trHideElem.style.display = 'none';
            });
            btnBuyElem.addEventListener('click', (e) => {
                let buyItElem = e.currentTarget.parentNode.parentNode;
                let total = Number(totalPriceElem.textContent);
                total += Number(buyItElem.querySelector('td:nth-of-type(2)').textContent);
                totalPriceElem.textContent = total.toFixed(2);
                buyItElem.nextSibling.remove();
                buyItElem.remove();
            });

        }
    });
}
