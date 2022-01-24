function generateReport() {
    let output = [];
    let [...arr] = document.querySelectorAll('thead th input');
    let obj = {};
    let flag = true;
    arr.forEach((x, i) => {

        if (x.checked) {

            let [...info] = document.querySelectorAll('tbody tr');
            info.forEach((y, j) => {
                let tdInfo = y.querySelectorAll('td')[i].textContent;
                if (flag) {
                    obj[x.attributes[1].value] = tdInfo;
                    output.push(Object.assign({}, obj));
                } else {
                    output[j][x.attributes[1].value] = tdInfo;
                }

            })
            flag = false;
        }

    });
    document.querySelector('#output').textContent = JSON.stringify(output);

}
