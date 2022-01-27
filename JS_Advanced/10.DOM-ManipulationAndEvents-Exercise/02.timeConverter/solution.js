function attachEventsListeners() {

    let inputDaysElement = document.getElementById('days');
    let inputHoursElement = document.getElementById('hours');
    let inputMinutesElement = document.getElementById('minutes');
    let inputSecondsElement = document.getElementById('seconds');

    let buttons = Array.from(document.querySelectorAll('input[value = "Convert"]'));
    buttons.forEach(x => {
        x.addEventListener('click', convertAndDisplay);
    });

    function convertAndDisplay(e){
        let elementToConvert = e.target.previousElementSibling.id;
        if (elementToConvert == "days") {
            inputHoursElement.value = Number(inputDaysElement.value) * 24;
            inputMinutesElement.value = Number(inputHoursElement.value) * 60;
            inputSecondsElement.value = Number(inputMinutesElement.value) * 60;
        }else if (elementToConvert == "hours") {
            inputDaysElement.value = Number(inputHoursElement.value) / 24;
            inputMinutesElement.value = Number(inputHoursElement.value) * 60;
            inputSecondsElement.value = Number(inputMinutesElement.value) * 60;
        }else if (elementToConvert == "minutes") {
            inputDaysElement.value = Number(inputMinutesElement.value) / 24 / 60;
            inputHoursElement.value = Number(inputMinutesElement.value) / 60;
            inputSecondsElement.value = Number(inputMinutesElement.value) * 60;
        }else if (elementToConvert == "seconds") {
            inputDaysElement.value = Number(inputSecondsElement.value) / 24 / 60 / 60;
            inputHoursElement.value = Number(inputDaysElement.value) * 24;
            inputMinutesElement.value = Number(inputHoursElement.value) * 60;
        }
    }
}