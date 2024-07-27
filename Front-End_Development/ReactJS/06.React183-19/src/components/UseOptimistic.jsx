import { useActionState, useState, useOptimistic } from 'react';
import uniqid from 'uniqid';

const createTodo = (title) => new Promise(resolve => setTimeout(() => resolve({ id: uniqid(), title }), 2000));

export default function UseOptimistic() {
    const [todos, setTodos] = useState([
        { id: 1, title: 'Clean' },
        { id: 2, title: 'Study' },
    ]);

    const [optimisticTodos, setOptimisticTodos] = useOptimistic(todos);

    const [error, formAction, isPending] = useActionState(async (previousState, formData) => {
        const title = formData.get('name');

        if (!title) {
            return 'Title is required'
        }

        setOptimisticTodos(prevTodos => [...prevTodos, { title, id: uniqid(), pending: true }])

        const newTodo = await createTodo(title);

        setTodos(prevTodos => [...prevTodos, newTodo]);

        return null
    }, null);

    return (
        <>
            <h2>Use Optimistic Hook</h2>

            <form action={formAction}>
                <input type="text" name="name" />
                <button type="submit" disabled={isPending}>Add</button>
            </form>

            {error && <p>{error}</p>}

            <ul>
                {optimisticTodos.map(todo => <li key={todo.id} style={todo.pending && { color: 'gray' }}>{todo.title}</li>)}
            </ul>
        </>
    );
}
