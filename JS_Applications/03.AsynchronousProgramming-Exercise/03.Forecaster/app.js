function attachEvents() {
    const inputElement = document.getElementById('location');
    const submitBtn = document.getElementById('submit');
    const forecastSectionElement = document.getElementById('forecast');

    const weather = {
        Sunny: '&#x2600',
        ['Partly sunny']: '&#x26C5',
        Overcast: '&#x2601',
        Rain: '&#x2614',
        Degrees: '&#176',
    }

    const divError = document.createElement('div');
    divError.setAttribute('class', 'label');
    divError.setAttribute('id', 'error');
    divError.textContent = 'Error';
    divError.style.display = 'none';
    divError.style.textAlign = 'center';
    document.getElementById('content').appendChild(divError);

    submitBtn.addEventListener('click', async () => {
        try {
            if (inputElement.value) {

                divError.style.display = 'none';
                const info = await getForecast(inputElement.value);
                inputElement.value = '';
                document.querySelector('.forecasts') ? document.querySelector('.forecasts').remove() : null;
                document.querySelector('.forecast-info') ? document.querySelector('.forecast-info').remove() : null;
                const divForecasts = document.createElement('div');
                divForecasts.setAttribute('class', 'forecasts');

                const spanSymbol = document.createElement('span');
                spanSymbol.setAttribute('class', 'condition symbol');
                spanSymbol.innerHTML = weather[info.current.forecast.condition];

                const spanCondition = document.createElement('span');
                spanCondition.setAttribute('class', 'condition');

                const spanCity = document.createElement('span');
                spanCity.setAttribute('class', 'forecast-data');
                spanCity.textContent = info.current.name;
                spanCondition.appendChild(spanCity);

                const spanDegrees = document.createElement('span');
                spanDegrees.setAttribute('class', 'forecast-data');
                spanDegrees.innerHTML = `${info.current.forecast.low}${weather.Degrees}/${info.current.forecast.high}${weather.Degrees}`;
                spanCondition.appendChild(spanDegrees);

                const spanWeather = document.createElement('span');
                spanWeather.setAttribute('class', 'forecast-data');
                spanWeather.textContent = info.current.condition;
                spanCondition.appendChild(spanWeather);

                divForecasts.appendChild(spanSymbol);
                divForecasts.appendChild(spanCondition);

                document.getElementById('current').appendChild(divForecasts);

                const divForecastInfo = document.createElement('div');
                divForecastInfo.setAttribute('class', 'forecast-info');

                for (const day of info.upcoming.forecast) {
                    const spanClassUpcoming = document.createElement('span');
                    spanClassUpcoming.setAttribute('class', 'upcoming');

                    const spanSymbol = document.createElement('span');
                    spanSymbol.setAttribute('class', 'symbol');
                    spanSymbol.innerHTML = weather[day.condition];

                    const spanDegrees = document.createElement('span');
                    spanDegrees.setAttribute('class', 'forecast-data');
                    spanDegrees.innerHTML = `${day.low}${weather.Degrees}/${day.high}${weather.Degrees}`;

                    const spanWeatherType = document.createElement('span');
                    spanWeatherType.setAttribute('class', 'forecast-data');
                    spanWeatherType.textContent = day.condition;

                    spanClassUpcoming.appendChild(spanSymbol);
                    spanClassUpcoming.appendChild(spanDegrees);
                    spanClassUpcoming.appendChild(spanWeatherType);
                    divForecastInfo.appendChild(spanClassUpcoming);
                }
                document.getElementById('upcoming').appendChild(divForecastInfo);

                forecastSectionElement.style.display = 'block';

            }

        } catch (error) {
            forecastSectionElement.style.display = 'none';
            divError.style.display = 'block';
            inputElement.value = '';
        }

    });


}

attachEvents();

async function getForecast(name) {
    const code = await getLocationCode(name);

    const [current, upcoming] = await Promise.all([
        getCurrent(code),
        getUpComing(code)
    ]);
    return { current, upcoming };
}

async function getLocationCode(name) {
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';

    const res = await fetch(url);
    const data = await res.json();

    return data.find(l => l.name == name).code;
}

async function getCurrent(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/today/${code}`;

    const res = await fetch(url);
    const data = await res.json();
    return data;
}

async function getUpComing(code) {
    const url = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`;

    const res = await fetch(url);
    const data = await res.json();

    return data;
}