function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchInfo = document.querySelector('#searchField').value;
      let [...info] = document.querySelectorAll('tbody tr');
      info.map(i => {
         const att = document.createAttribute('class');
         att.value = 'select';
         document.querySelector('#searchField').value = '';
         i.textContent.includes(searchInfo)? i.setAttributeNode(att) : att.value = ''; i.setAttributeNode(att);
        
      });
   }
}