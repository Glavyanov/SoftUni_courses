function solve() {
    const infoElement = document.querySelector('#info span');
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    let stop = {
        next: 'depot',
    };

    async function depart() {
        departBtn.disabled = true;

        const url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;
        try {
            const res = await fetch(url);
            stop = await res.json();
            infoElement.textContent = `Next stop ${stop.name}`;

        } catch (err) {
            infoElement.textContent = 'Error';
        }
        arriveBtn.disabled = false;
    }

    function arrive() {
        if (stop.name) {
            infoElement.textContent = `Arriving at ${stop.name}`;
            
        }else {
            infoElement.textContent = 'Error';
        }

        departBtn.disabled = false;
        arriveBtn.disabled = true;

    }

    return {
        depart,
        arrive
    };
}

let result = solve();