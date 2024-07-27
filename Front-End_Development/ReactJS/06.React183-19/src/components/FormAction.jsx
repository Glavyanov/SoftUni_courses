export default function FormAction() {
    const formAction = (formData) => {
        console.log(formData.get('name'));
    };

    return (
        <>
            <h2>Form Action</h2>
            <form action={formAction}>
                <input type="text" name="name" />
                <button>Update</button>
            </form>
        </>
    );
}
