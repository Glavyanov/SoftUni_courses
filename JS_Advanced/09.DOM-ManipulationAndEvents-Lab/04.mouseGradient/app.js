function attachGradientEvents() {
    let divElement = document.querySelector('#gradient');
    let result = document.querySelector('#result');
    divElement.addEventListener("mousemove", function(event) {
        result.textContent = `${Math.floor((event.offsetX / 3))}%`;
        
    });
}