const Movie = ({title, year, cast}) => {
    const actors = cast.map(a => {
        return <p key={a} style={{backgroundColor: "yellow", color: "chocolate"}} >{a}</p>
    });

    return(
        <section>
            <p style={{backgroundColor: "blue", color: "white"}} >{title}</p>
            <p>{year}</p>
            <div>{actors}</div>
        </section>
    );
};

export default Movie;