const docRoot = document.getElementById('root');
const reactJSXRoot = ReactDOM.createRoot(docRoot);
// const header = React.createElement('h1', { style: { color: 'red', backgroundColor: "black" } }, 'Hello from preReactJSX');
// // console.log(JSON.parse(JSON.stringify(header)));
//Use JSX syntax

const content = (
    <div className="content">
        <header>
            <h1 style={{ color: "red", backgroundColor: "black" }}>Hello from ReactJSX</h1>
            <h2>Slogan Here!</h2>
            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam, in.</p>
        </header>
        <main>
            <section>
                <h2>Hello from main section</h2>
            </section>
        </main>
        <footer>
            <p>Hello From footer</p>
        </footer>
    </div>
);

reactJSXRoot.render(content);