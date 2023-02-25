import Movie from "./Movie";

    const movies =[
        {title: "Man on fire", year: "2004",cast: ['Denzel Washington', 'Dakota Fanning']},
        {title: "Training Day", year: "2004",cast: ['Denzel Washington', 'Ethan Hawke']},
        {title: "American Gangster", year: "2004",cast: ['Denzel Washington', 'Russell Crowe']},
    ];

const MovieList = () => {
    return movies.map(m => {
        return (
                <Movie 
                key={m.title}
                title={m.title}
                year={m.year}
                cast={m.cast}
            />
        );
    });
};

export default MovieList;