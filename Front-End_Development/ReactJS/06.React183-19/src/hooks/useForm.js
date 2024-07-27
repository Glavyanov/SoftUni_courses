import { useState } from 'react';

export function useForm(submitCallback, initialValues) {
    const [values, setValues] = useState(initialValues);
    
    // TODO: add support for checkbox
    const changeHandler = (e) => {
        setValues(state => ({
            ...state,
            [e.target.name]: e.target.value
        }));
    };

    const submitHandler = async (e) => {
        e.preventDefault();
        
        await submitCallback(values);

        setValues(initialValues);
    };

    return {
        values,
        changeHandler,
        submitHandler,
    };
}
