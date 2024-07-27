import './App.css'
import ContextComponent from './components/Context'
import FormAction from './components/FormAction'
import TodoList from './components/TodoList'
import UseActionState from './components/UseActionState'
import UseFormStatus from './components/UseFormStatus'
import UseHook from './components/UseHook'
import UseOptimistic from './components/UseOptimistic'
import UseTransition from './components/UseTransition'

function App() {
    return (
        <>
            <FormAction />
            <UseFormStatus />
            <UseTransition />
            <UseActionState />
            <UseOptimistic />
            <UseHook />
            <TodoList />
            {/* <ContextComponent /> */}
        </>
    )
}

export default App
