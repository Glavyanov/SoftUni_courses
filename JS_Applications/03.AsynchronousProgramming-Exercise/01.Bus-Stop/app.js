function getInfo() {
    let inputStopIDElement = document.getElementById('stopId');
    let stopNameElement = document.getElementById('stopName');
    const busesElement = document.getElementById('buses');
    const baseUrl = 'http://localhost:3030/jsonstore/bus/businfo/';

    stopNameElement.textContent = 'Loading...';
    busesElement.replaceChildren();
   
        fetch(`${baseUrl}${inputStopIDElement.value}`)
        .then(response => response.json())
        .then(data => {
            stopNameElement.textContent = data.name;
            
            Object.entries(data.buses).forEach(bus => {
                let liElement = document.createElement('li');
                liElement.textContent = `Bus ${bus[0]} arrives in ${bus[1]} minutes`;
                busesElement.appendChild(liElement);
            })
        })
        .catch(err => {
            stopNameElement.textContent = 'Error';
        });
}