function loadRepos() {
   let divElement = document.getElementById('res');
   const baseUrl = 'https://api.github.com/users/testnakov/repos';
   const httpRequest = new XMLHttpRequest();
   // httpRequest.addEventListener('readystatechange', () => {
   //    if (httpRequest.readyState == 4 && httpRequest.status == 200) {
   //       divElement.textContent = httpRequest.responseText;
   //    }
   // });
   httpRequest.open("GET",baseUrl);
   httpRequest.onreadystatechange = () =>{
      if (httpRequest.readyState == 4 && httpRequest.status == 200) {
         divElement.textContent = httpRequest.responseText;
      }
   }
   httpRequest.send();
}