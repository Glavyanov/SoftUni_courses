import { useActionState } from 'react';

const updateName = (name) => new Promise(resolve => setTimeout(() => resolve(name), 2000));

export default function UseActionState() {
    const formHandler = async (previousState, formData) => {
        const result = await updateName(formData.get('name'));

        console.log(result);

        return null;
    }

    const [state, formAction, isPending] = useActionState(formHandler, { name: '' });

    return (
        <>
            <h2>useActionState</h2>
            <form action={formAction}>
                <input type="text" name="name" />
                <button  type="submit" disabled={isPending}>Update</button>
            </form>
        </>
    );
}
