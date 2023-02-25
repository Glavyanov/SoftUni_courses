var docRoot = document.getElementById('root');
var reactJSXRoot = ReactDOM.createRoot(docRoot);
// const header = React.createElement('h1', { style: { color: 'red', backgroundColor: "black" } }, 'Hello from preReactJSX');
// // console.log(JSON.parse(JSON.stringify(header)));
//Use JSX syntax

var content = React.createElement(
    "div",
    { className: "content" },
    React.createElement(
        "header",
        null,
        React.createElement(
            "h1",
            { style: { color: "red", backgroundColor: "black" } },
            "Hello from ReactJSX"
        ),
        React.createElement(
            "h2",
            null,
            "Slogan Here!"
        ),
        React.createElement(
            "p",
            null,
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam, in."
        )
    ),
    React.createElement(
        "main",
        null,
        React.createElement(
            "section",
            null,
            React.createElement(
                "h2",
                null,
                "Hello from main section"
            )
        )
    ),
    React.createElement(
        "footer",
        null,
        React.createElement(
            "p",
            null,
            "Hello From footer"
        )
    )
);

reactJSXRoot.render(content);