import { useState } from "react";

const Counter = (props) => {
    const [counter, setCounter] = useState(0);

    const onClickIncrement = (e) => {
        setCounter(c => c + 1);
    };
    const onClickDecrement = (e) => {
        setCounter(c => c - 1);
    };
    const onClickReset = (e) => {
        setCounter(c => 0);
    };

    if (counter == 1) {
        document.getElementById('body').style.cssText = 'background: linear-gradient(90deg, rgba(2, 0, 36, 1) 0%, rgba(30, 93, 162, 1) 29%, rgba(29, 204, 134, 1) 86%);';
    } else if (counter == 2) {
        document.getElementById('body').style.cssText = 'background: linear-gradient(90deg, rgba(131, 58, 180, 1) 0%, rgba(253, 77, 29, 1) 40%, rgba(177, 119, 36, 1) 100%);';
    } else if (counter == 3) {
        document.getElementById('body').style.cssText = 'background: linear-gradient(180deg, rgba(63,94,251,1) 23%, rgba(251,252,70,1) 66%);';
    } else {
        document.getElementById('body').style.background = 'none';
    }

    return (
        <div>
            <h3>Counter: {counter < 0 ? 0 : counter}</h3>
            {
                counter < 10
                    ? <button onClick={onClickIncrement}>+</button>
                    :
                    null
            }
            {props.reset && <button onClick={onClickReset}>0</button>}
            <button onClick={onClickDecrement}>-</button>
        </div>
    );

};

export default Counter;