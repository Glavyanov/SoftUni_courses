function notify(message) {
  let divNotification = document.querySelector('#notification');
   divNotification.textContent = message;
   divNotification.style.display = 'block';
   divNotification.addEventListener('click', (e)=> {
      e.currentTarget.style.display = 'none';
   });
}