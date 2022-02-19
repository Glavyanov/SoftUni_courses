function solve() {
    let firstNameElem = document.querySelector('#fname');
    let lastNameElem = document.querySelector('#lname');
    let emailElem = document.querySelector('#email');
    let birthElem = document.querySelector('#birth');
    let positionElem = document.querySelector('#position');
    let salaryElem = document.querySelector('#salary');
    let addWorkerBtn = document.querySelector('#add-worker');
    let tableContentElem = document.querySelector('#tbody');
    let sumSalaryElem = document.querySelector('#sum');

    addWorkerBtn.addEventListener('click', (e) => {
        e.preventDefault();

        if (firstNameElem.value && lastNameElem.value && emailElem.value
            && birthElem.value && positionElem.value && salaryElem.value) {
            let trElem = document.createElement('tr');

            let tdElemFirst = document.createElement('td');
            tdElemFirst.textContent = firstNameElem.value;

            let tdElemLast = document.createElement('td');
            tdElemLast.textContent = lastNameElem.value;

            let tdEmailElem = document.createElement('td');
            tdEmailElem.textContent = emailElem.value;

            let tdBirthElem = document.createElement('td');
            tdBirthElem.textContent = birthElem.value;

            let tdPositionElem = document.createElement('td');
            tdPositionElem.textContent = positionElem.value;

            let tdSalaryElem = document.createElement('td');
            tdSalaryElem.textContent = salaryElem.value;

            let tdButtonsElem = document.createElement('td');

            let buttonFiredElem = document.createElement('button');
            buttonFiredElem.setAttribute('class', 'fired');
            buttonFiredElem.textContent = 'Fired';

            let buttonEditElem = document.createElement('button');
            buttonEditElem.setAttribute('class', 'edit');
            buttonEditElem.textContent = 'Edit';

            tdButtonsElem.appendChild(buttonFiredElem);
            tdButtonsElem.appendChild(buttonEditElem);

            trElem.appendChild(tdElemFirst);
            trElem.appendChild(tdElemLast);
            trElem.appendChild(tdEmailElem);
            trElem.appendChild(tdBirthElem);
            trElem.appendChild(tdPositionElem);
            trElem.appendChild(tdSalaryElem);
            trElem.appendChild(tdButtonsElem);

            tableContentElem.appendChild(trElem);
            let salaries = Number(sumSalaryElem.textContent);
            salaries += Number(tdSalaryElem.textContent);
            sumSalaryElem.textContent = salaries.toFixed(2);

            firstNameElem.value = '';
            lastNameElem.value = '';
            emailElem.value = '';
            birthElem.value = '';
            positionElem.value = '';
            salaryElem.value = '';

            buttonEditElem.addEventListener('click', (e) => {
                let trEditElem = e.currentTarget.parentNode.parentNode;

                firstNameElem.value = trEditElem.children[0].textContent;
                lastNameElem.value = trEditElem.children[1].textContent;
                emailElem.value = trEditElem.children[2].textContent;
                birthElem.value = trEditElem.children[3].textContent;
                positionElem.value = trEditElem.children[4].textContent;
                salaryElem.value = trEditElem.children[5].textContent;

                salaries = Number(sumSalaryElem.textContent);
                salaries -= Number(salaryElem.value);
                sumSalaryElem.textContent = salaries.toFixed(2);

                trEditElem.remove();
            });

            buttonFiredElem.addEventListener('click', (e) => {
                let trFiredElem = e.currentTarget.parentNode.parentNode;
                let allSalaries = Number(sumSalaryElem.textContent);
                allSalaries -= Number(trFiredElem.children[5].textContent)
                sumSalaryElem.textContent = allSalaries.toFixed(2);

                trFiredElem.remove();
            });

        }
    })

}
solve()