export default function Todo({
    _id,
    text,
    isCompleted,
    toggleTodoStatus,
}) {
    return (
        <tr className={`todo${isCompleted ? ' is-completed' : ''}`} >
            <td>{text}</td>
            <td>{isCompleted ? 'Complete' : 'Incomplete'}</td>
            <td className="todo-action">
                <button className="btn todo-btn" onClick={() => toggleTodoStatus(_id)}>Change status</button>
            </td>
        </tr>
    );
};