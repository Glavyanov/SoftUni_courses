import { createContext, use } from "react";

const UserContext = createContext();

function NestedComponent() {
    const contextData = use(UserContext); // Can be used conditionally

    return <p>{contextData}</p>
}

export default function ContextComponent() {
    return (
        <UserContext value="Pesho">
            <NestedComponent />
        </UserContext>
    );
}
