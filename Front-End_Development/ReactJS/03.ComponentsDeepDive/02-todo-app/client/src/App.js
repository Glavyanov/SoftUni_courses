import './App.css';
import{useEffect, useState} from 'react';
import Footer from './components/Footer';
import Header from './components/Header';
import Loading from './components/Loading';
import TodoTable from './components/TodoTable';

function App() {

    const[todos, setTodos] = useState([]);
    const[loading, setLoading]= useState(true);

    useEffect(() => {
        fetch('http://localhost:3030/jsonstore/todos')
        .then(res => res.json())
        .then(data => {
            setTodos(Object.values(data)); // setTodos(Object.keys(data).map(id => ({ id, ...data[id] })));
            setLoading(false);
        }) 
    },[]);

    const toggleTodoStatus = (id) => {
        setTodos(state => state.map(t => t._id === id ? ({...t, isCompleted: !t.isCompleted}) : t));
    }

    const onTodoAdd = () => {
        const lastId = Number(todos.length);
        const text = prompt('Task name:');
        const newTask = { _id:`todo_${lastId + 1}`, text, isCompleted: false};

        setTodos(state => [newTask, ...state]);
    }
    
    return (
        <div className="App">

            <Header />

            <main className="main">

                <section className="todo-list-container">
                    <h1>Todo List</h1>

                    <div className="add-btn-container">
                        <button className="btn" onClick={onTodoAdd}>+ Add new Todo</button>
                    </div>

                    <div className="table-wrapper">
                        { loading 
                            ? <Loading />
                            : <TodoTable todos={todos} toggleTodoStatus={toggleTodoStatus}/>
                        }
                    </div>

                </section>
            </main>

            <Footer />

        </div>
    );
}

export default App;
