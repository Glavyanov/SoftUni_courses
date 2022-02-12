function solve() {
    let inputTaskEl = document.querySelector('.wrapper section:first-of-type #task');
    let textDescriptionEl = document.querySelector('.wrapper section:first-of-type #description');
    let dateEl = document.querySelector('.wrapper section:first-of-type #date');
    let addBtn = document.querySelector('#add');
    let openSection = document.querySelector('.wrapper section:nth-of-type(2) div:nth-of-type(2)');
    let inProgressSection = document.querySelector('.wrapper section:nth-of-type(3) #in-progress');
    let completeSection = document.querySelector('.wrapper section:nth-of-type(4) div:nth-of-type(2)');

    addBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (inputTaskEl.value && textDescriptionEl.value && dateEl.value &&
            inputTaskEl.value.search(/^\s*$/) == -1 && textDescriptionEl.value.search(/^\s*$/) == -1 &&
            dateEl.value.search(/^\s*$/) == -1) {
            let articleEl = document.createElement('article');
            let h3El = document.createElement('h3');
            h3El.textContent = inputTaskEl.value;
            let paragraphDescriptEl = document.createElement('p');
            paragraphDescriptEl.textContent = `Description: ${textDescriptionEl.value}`;
            let paragraphDateEl = document.createElement('p');
            paragraphDateEl.textContent = `Due Date: ${dateEl.value}`;
            let divFlexEl = document.createElement('div');
            divFlexEl.setAttribute('class', 'flex');
            let btnGreen = document.createElement('button');
            btnGreen.setAttribute('class', 'green');
            btnGreen.textContent = 'Start';
            let btnRed = document.createElement('button');
            btnRed.setAttribute('class', 'red');
            btnRed.textContent = 'Delete';
            divFlexEl.appendChild(btnGreen);
            divFlexEl.appendChild(btnRed);
            articleEl.appendChild(h3El);
            articleEl.appendChild(paragraphDescriptEl);
            articleEl.appendChild(paragraphDateEl);
            articleEl.appendChild(divFlexEl);
            openSection.appendChild(articleEl);
            inputTaskEl.value = '';
            textDescriptionEl.value = '';
            dateEl.value = '';

            btnGreen.addEventListener('click', () => {
                inProgressSection.appendChild(articleEl);
                btnGreen.classList.replace('green', 'red');
                btnGreen.textContent = 'Delete';
                btnRed.classList.replace('red', 'orange');
                btnRed.textContent = 'Finish';
                btnRed
                btnGreen.addEventListener('click', (e) => {
                    e.currentTarget.parentNode.parentNode.remove();
                });
                btnRed.addEventListener('click', () => {
                    completeSection.appendChild(articleEl);
                    articleEl.getElementsByClassName('flex')[0].remove();
                });
            });
            btnRed.addEventListener('click', () => {
                openSection.getElementsByTagName('article')[0].remove();

            });
        }
    });
}
// function solve() {
//     let addButtonElement = document.querySelector('#add');
//     let inputTaskElement = document.querySelector('#task');
//     let textAreaElement = document.querySelector('#description');
//     let inputDateElement = document.querySelector('#date');
 
//     let sections = document.querySelector('.wrapper');
 
//     addButtonElement.addEventListener('click', addOpenSection)
 
//     function addOpenSection(e) {
//         e.preventDefault();
//         //Second Section
//         if (inputTaskElement.value != '' && textAreaElement.value !== '' && inputDateElement.value !== '') {
//             let articleElement = document.createElement('article');
 
//             let h3Element = document.createElement('h3');
//             let firstP = document.createElement('p');
//             let secondP = document.createElement('p');
//             let divElement = document.createElement('div');
//             let startButton = document.createElement('button');
//             let deleteButton = document.createElement('button');
 
//             h3Element.textContent = inputTaskElement.value;
//             firstP.textContent = `Description: ${textAreaElement.value}`;
//             secondP.textContent = `Due Date: ${inputDateElement.value}`;
//             startButton.className = "green";
//             startButton.textContent = "Start";
//             deleteButton.className = "red";
//             deleteButton.textContent = "Delete";
//             divElement.className = "flex";
//             divElement.appendChild(startButton);
//             divElement.appendChild(deleteButton);
 
//             //Third section
//             startButton.addEventListener('click', addInProgressSection);
//             deleteButton.addEventListener('click', deleteElement);
 
//             articleElement.appendChild(h3Element);
//             articleElement.appendChild(firstP);
//             articleElement.appendChild(secondP);
//             articleElement.appendChild(divElement);
 
//             sections.children[1].children[1].appendChild(articleElement);
 
//             inputTaskElement.value = '';
//             textAreaElement.value = '';
//             inputDateElement.value = '';
//         }
//     }
 
//     function addInProgressSection(e) {
//         let articleElement = document.createElement('article');
 
//                 let h3Element = document.createElement('h3');
//                 let firstP = document.createElement('p');
//                 let secondP = document.createElement('p');
//                 let divElement = document.createElement('div');
//                 let deleteButton = document.createElement('button');
//                 let finishButton = document.createElement('button');
 
//                 let courseName = e.target.parentElement.parentElement.children[0];
//                 let courseDescription = e.target.parentElement.parentElement.children[1];
//                 let courseDate = e.target.parentElement.parentElement.children[2];
 
//                 h3Element.textContent = courseName.textContent;
//                 firstP.textContent = courseDescription.textContent;
//                 secondP.textContent = courseDate.textContent;
//                 finishButton.className = "orange";
//                 finishButton.textContent = "Finish";
//                 deleteButton.className = "red";
//                 deleteButton.textContent = "Delete";
//                 divElement.className = "flex";
//                 divElement.appendChild(deleteButton);
//                 divElement.appendChild(finishButton);
 
//                 //Last section
//                 finishButton.addEventListener('click', lastSection);
//                 deleteButton.addEventListener('click', deleteElement);
 
//                 articleElement.appendChild(h3Element);
//                 articleElement.appendChild(firstP);
//                 articleElement.appendChild(secondP);
//                 articleElement.appendChild(divElement);
 
//                 sections.children[2].children[1].appendChild(articleElement);
//                 deleteElement(e);
//     }
 
//     function lastSection(e) {
//                     let courseName = e.target.parentElement.parentElement.children[0];
//                     let courseDescription = e.target.parentElement.parentElement.children[1];
//                     let courseDate = e.target.parentElement.parentElement.children[2];
 
//                     let articleElement = document.createElement('article');
//                     let h3Element = document.createElement('h3');
//                     let firstP = document.createElement('p');
//                     let secondP = document.createElement('p');
 
//                     h3Element.textContent = courseName.textContent;
//                     firstP.textContent = courseDescription.textContent;
//                     secondP.textContent = courseDate.textContent;
                    
//                     articleElement.appendChild(h3Element);
//                     articleElement.appendChild(firstP);
//                     articleElement.appendChild(secondP);
 
//                     sections.children[3].children[1].appendChild(articleElement);
//                     deleteElement(e);
//     }
 
//     function deleteElement(e) {
//         let firstParent = e.target.parentElement.parentElement;
//             let secondParent = firstParent.parentElement;
//             secondParent.removeChild(firstParent);
//     }
// }