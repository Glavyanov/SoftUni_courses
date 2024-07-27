import { useEffect, useState } from "react";

const todosData = [
    { id: 1, isCompleted: true, title: 'Clean' },
    { id: 2, isCompleted: false, title: 'Study' },
    { id: 3, isCompleted: false, title: 'Fitness' },
    { id: 4, isCompleted: false, title: 'Heroes of JS' },
];

const getTodos = () => new Promise(resolve => setTimeout(() => resolve(todosData), 2000));

export default function TodoList() {
    const [todos, setTodos] = useState([]);

    useEffect(() => {
        (async () => {
            const result = await getTodos();
            setTodos(result);
        })();
    }, []);

    const toggleHalndler = (todoId) => {
        setTodos(oldTodos => oldTodos.map(todo =>
            todo.id === todoId
                ? { ...todo, isCompleted: !todo.isCompleted }
                : todo
        ));
    };

    return (
        <>
            <h2>Todo List</h2>
            <ul>
                {todos.map(todo => (
                    <Todo
                        key={todo.id}
                        id={todo.id}
                        title={todo.title}
                        isCompleted={todo.isCompleted}
                        onToggle={toggleHalndler}
                    />
                ))}
            </ul>
        </>
    );
}

function Todo({
    id,
    title,
    isCompleted,
    onToggle,
}) {
    console.log('Todo Render - ' + title);
    return (
        <li
            onClick={() => onToggle(id)}
            style={isCompleted ? { textDecoration: 'line-through' } : {}}
        >
            {title}
        </li>
    );
}
