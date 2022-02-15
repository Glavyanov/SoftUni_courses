window.addEventListener('load', solution);

function solution() {
  let fullNameElem = document.querySelector('#fname');
  let emailElem = document.querySelector('#email');
  let phoneElem = document.querySelector('#phone');
  let addressElem = document.querySelector('#address');
  let codeElem = document.querySelector('#code');
  let infoPreviewElem = document.querySelector('#infoPreview');
  let submitBtn = document.querySelector('#submitBTN');
  let editBtn = document.querySelector('#editBTN');
  let continueBtn = document.querySelector('#continueBTN');
  let divBlockElem = document.querySelector('#block');

  submitBtn.addEventListener('click', () => {
    if (fullNameElem.value && emailElem.value) {
      let ulNameElem = document.createElement('li');
      ulNameElem.textContent = `Full Name: ${fullNameElem.value}`;

      let ulEmailElem = document.createElement('li');
      ulEmailElem.textContent = `Email: ${emailElem.value}`;

      let ulPhoneElem = document.createElement('li');
      ulPhoneElem.textContent = `Phone Number: ${phoneElem.value}`;

      let ulAddressElem = document.createElement('li');
      ulAddressElem.textContent = `Address: ${addressElem.value}`;

      let ulCodeElem = document.createElement('li');
      ulCodeElem.textContent = `Postal Code: ${codeElem.value}`;
      infoPreviewElem.appendChild(ulNameElem);
      infoPreviewElem.appendChild(ulEmailElem);
      infoPreviewElem.appendChild(ulPhoneElem);
      infoPreviewElem.appendChild(ulAddressElem);
      infoPreviewElem.appendChild(ulCodeElem);

      fullNameElem.value = '';
      emailElem.value = '';
      phoneElem.value = '';
      addressElem.value = '';
      codeElem.value = '';

      submitBtn.disabled = true;
      editBtn.disabled = false;
      continueBtn.disabled = false;
      editBtn.addEventListener('click', () => {
        submitBtn.disabled = false;
        editBtn.disabled = true;
        continueBtn.disabled = true;

        fullNameElem.value = ulNameElem.textContent.split(': ')[1];
        emailElem.value = ulEmailElem.textContent.split(': ')[1];
        phoneElem.value = ulPhoneElem.textContent.split(': ')[1];
        addressElem.value = ulAddressElem.textContent.split(': ')[1];
        codeElem.value = ulCodeElem.textContent.split(': ')[1];
        Array.from(document.querySelectorAll('#infoPreview li')).forEach(el => el.remove())

      });
      continueBtn.addEventListener('click', () => {

        let h3Element = document.createElement('h3');
        h3Element.textContent = 'Thank you for your reservation!';
        Array.from(divBlockElem.childNodes).forEach(el => el.remove());
        divBlockElem.appendChild(h3Element);
      });
    }

  });
}