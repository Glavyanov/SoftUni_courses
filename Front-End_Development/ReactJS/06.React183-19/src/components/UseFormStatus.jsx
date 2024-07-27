import { useFormStatus } from 'react-dom';

const updateName = (name) => new Promise(resolve => setTimeout(() => resolve(name), 2000));

function Submit() {
    const { pending, data, method, action } = useFormStatus();

    return <button type="submit" disabled={pending}>Update</button>;
}

Submit.displayName = 'Submit';

export default function UseFormStatus() {
    const formAction = async (formData) => {
        const result = await updateName(formData.get('name'));

        console.log(result);
    }

    return (
        <>
            <h2>useFormStatus</h2>
            <form action={formAction}>
                <input type="text" name="name" />
                <Submit />
            </form>
        </>
    );
}
