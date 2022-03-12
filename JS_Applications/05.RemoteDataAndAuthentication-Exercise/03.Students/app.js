(function () {

    getStudents();
    document.getElementById('submit').addEventListener('click', submitStudentAndGetAll);

})();

async function submitStudentAndGetAll(e) {
    e.preventDefault();
    e.target.disabled = true;
    const formElement = document.getElementById('form');
    const url = 'http://localhost:3030/jsonstore/collections/students';

    const form = new FormData(formElement);
    const firstName = form.get('firstName');
    const lastName = form.get('lastName');
    const facultyNumber = form.get('facultyNumber');
    const grade = form.get('grade');
    if (!firstName || !lastName || !facultyNumber || !grade || !firstName.search(/^\s*$/)
        || !lastName.search(/^\s*$/) || !facultyNumber.search(/^\s*$/) || !grade.search(/^\s*$/)) {

        alert('All fields must be non-empty');

    } else {
        await Promise.all([
            submit(),
            getStudents()
        ])
        formElement.reset();
    }

    e.target.disabled = false;

    async function submit() {
        try {
            await fetch(url, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    firstName,
                    lastName,
                    facultyNumber,
                    grade
                })
            });
        } catch (error) {
            alert('Server Error');
        }
    }

}
async function getStudents() {
    const url = 'http://localhost:3030/jsonstore/collections/students';
    const tableElement = document.querySelector('#results tbody');
    tableElement.replaceChildren();
    try {
        const res = await fetch(url);
        const data = await res.json();
        Object.values(data).forEach(student => {
            const tableRow = document.createElement('tr');
            tableRow.innerHTML = `
                <th>${student.firstName}</th>
                <th>${student.lastName}</th>
                <th>${student.facultyNumber}</th>
                <th>${student.grade}</th>
                `;
            tableElement.appendChild(tableRow);
        });
    } catch (error) {
        alert('Server Error');
    }
}