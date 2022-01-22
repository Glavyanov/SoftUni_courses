function toggle() {
    if (document.querySelector('#accordion .button').textContent === 'More') {
        document.querySelector('#accordion .button').textContent = 'Less';
        document.querySelector('#accordion #extra').style.display = 'block';
        
    }else{
        document.querySelector('#accordion .button').textContent = 'More';
        document.querySelector('#accordion #extra').style.display = 'none';
    }
}