function create(words) {
   let divContent = document.querySelector('div#content');
   for (const word of words) {
      let paragraphElement = document.createElement('p');
      paragraphElement.textContent = word;
      paragraphElement.style.display = 'none';
      let divElement = document.createElement('div');
      divElement.appendChild(paragraphElement);
      divContent.appendChild(divElement);
   }
   divContent.addEventListener('click',(e) => e.target.firstChild.style.display = 'block');
}