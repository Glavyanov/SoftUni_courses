function validate() {
    const submitBtn = document.querySelector('#submit');
    submitBtn.type = "button";
    const userName = document.querySelector('#username');
    const email = document.querySelector('#email');
    const password = document.querySelector('#password');
    const confirmPassword = document.querySelector('#confirm-password');
    const companyCheckBox = document.getElementById('company');
    const companyInfo = document.querySelector('#companyInfo');
    const companyNumber = document.getElementById('companyNumber')
    companyCheckBox.addEventListener('change', (e) => {
        if (e.currentTarget.checked) {
            companyInfo.style.display = 'block';
        } else {
            companyInfo.style.display = 'none';
        }
    });
    submitBtn.addEventListener('click', (e) => {
        
        let count = 0;
        if (userName.value.search(/^[\w]{3,20}$/)) {
            userName.style.borderColor = 'red';
            count--;
        } else {
            userName.style.border = '';
            count++;
        }
        if (email.value.match(/^[^@.]+@[^@]*\.[^@]*$/gm)) {
            email.style.border = '';
            count++;
        } else {
            email.style.borderColor = 'red';
            count--;
        }
        if (password.value.match(/^[\w]{5,15}$/) && password.value === confirmPassword.value) {
            password.style.border = '';
            count++;
            confirmPassword.style.border = '';
        } else {

            password.style.borderColor = 'red';
            count--;
            confirmPassword.style.borderColor = 'red';

        }
        if (companyCheckBox.checked) {
           
            if (companyNumber.value.match(/^[\d]{4}$/)) {
                if (Number(companyNumber.value) >= 1000 && Number(companyNumber.value) <= 9999) {
                    companyNumber.style.border = '';
                    count++;
                } else {
                    companyNumber.style.borderColor = 'red';
                    count--;
                   
                }
            } else {
                companyNumber.style.borderColor = 'red';
                count--;
            }
            if (count == 4) {
                document.querySelector('#valid').style.display = 'block';
            } else {
                document.querySelector('#valid').style.display = 'none';
            }
        } else {
            companyNumber.value = '';
            if (count == 3) {
                document.querySelector('#valid').style.display = 'block';
            } else {
                document.querySelector('#valid').style.display = 'none';
            }
        }
    });
}
