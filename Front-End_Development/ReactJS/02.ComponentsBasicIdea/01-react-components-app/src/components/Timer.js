import { useState } from "react";

const Timer = (props) => {

    const [seconds, setSeconds] = useState(props.start);
    
    setTimeout(()=>{
        setSeconds((sec) => sec + 1); // updater function
    },1000);
    
    return (
        <div>
            Time: {seconds}s
        </div>
    );
 };

export default Timer;