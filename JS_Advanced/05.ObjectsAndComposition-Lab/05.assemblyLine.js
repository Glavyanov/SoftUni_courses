function createAssemblyLine() {
    let result = {
        hasClima(myCar) {

            myCar['temp'] = 21;
            myCar['tempSettings'] = 21;
            myCar['adjustTemp'] = () => {
                myCar.temp < myCar.tempSettings ? myCar.temp++ : myCar.temp--;
            }
        },
        hasAudio(myCar) {
            myCar['currentTrack'] = null;
            myCar['nowPlaying'] = () => {
                if (myCar.currentTrack !== null) {
                    console.log(`Now playing '${myCar.currentTrack.name}' by ${myCar.currentTrack.artist}`);
                }
            }
        },
        hasParktronic(myCar) {
            myCar['checkDistance'] = (distance) => {
                console.log(distance < 0.1 ? 'Beep! Beep! Beep!' : distance < 0.25 ? 'Beep! Beep!' :
                    distance < 0.5 ? 'Beep!' : '');
            }
        },
    }
    return result;
}
const assemblyLine = createAssemblyLine();

let myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);
//-------------------------------------------------
assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();
//-------------------------------------------------
assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);
console.log(myCar);
