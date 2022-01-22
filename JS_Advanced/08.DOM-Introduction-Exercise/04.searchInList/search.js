function search() {
   let [...towns] = document.querySelectorAll('#towns li');
   let search = document.querySelector('#searchText').value;
   let count = 0;

   towns.forEach(x => {
      if (x.textContent.includes(search)) {
         x.style.fontWeight = 'bold';
         x.style.textDecoration = 'underline';
         count++;
      } else {
         x.style.fontWeight = 'normal';
         x.style.textDecoration = 'none';
      }
   });

   count ? document.querySelector('#result').textContent = `${count} matches found` : document.querySelector('#result').textContent = '';
}