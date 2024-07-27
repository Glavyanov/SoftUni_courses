import { useTransition } from "react";

const updateName = (name) => new Promise(resolve => setTimeout(() => resolve(name), 2000));

export default function UseTransition() {
    const [isPending, startTransition] = useTransition();

    const formAction = (formData) => {
        startTransition(async () => {
            const result = await updateName(formData.get('name'));

            console.log(result);
        });
    };

    return (
        <>
            <h2>useTransition</h2>
            <form action={formAction}>
                <input name="name" />
                <button disabled={isPending}>
                    Update
                </button>
            </form>
        </>
    );
}
