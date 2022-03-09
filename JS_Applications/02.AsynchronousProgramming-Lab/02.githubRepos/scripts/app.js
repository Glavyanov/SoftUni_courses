function loadRepos() {
	let ulElement = document.getElementById('repos');
	let inputElement = document.getElementById('username');
	let baseUrl = 'https://api.github.com/';
	let url = `${baseUrl}users/${inputElement.value}/repos`;

	fetch(url)
	     .then(response => response.json())
		 .then(data => {
			ulElement.innerHTML ='';
			 data.forEach(x => {
				let liElem = document.createElement('li');
				let aElem = document.createElement('a');
				aElem.setAttribute('href', `${baseUrl}repos/${x.full_name}`);
				aElem.textContent = x.full_name;
				liElem.appendChild(aElem);
				ulElement.appendChild(liElem);
			 })
		 })
		 .catch(err => console.log(err));

}