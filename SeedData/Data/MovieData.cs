using OMovies.Models;

public static class MovieData
{
    public static List<Movie> GetMovies()
    {
        return new List<Movie>
        {
            new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R",
                    Director = "Rob Reiner",
                    MainCast = "Billy Crystal, Meg Ryan",
                    Synopsis = "Harry and Sally have known each other for years, and are very good friends, but they fear sex would ruin the friendship.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/when-harry-met-sarry.jpeg"
                },
                new Movie
                {
                    Title = "Ghostbusters",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "G",
                    Director = "Ivan Reitman",
                    MainCast = "Bill Murray, Dan Aykroyd, Harold Ramis",
                    Synopsis = "Three eccentric parapsychology professors set up shop as a unique ghost removal service in New York City.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/ghostbasters.png"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "G",
                    Director = "Ivan Reitman",
                    MainCast = "Bill Murray, Dan Aykroyd, Sigourney Weaver",
                    Synopsis = "The Ghostbusters return to save New York from a massive underground river of slime and a resurrected 16th-century tyrant.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/ghostbasters2.jpeg"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "NA",
                    Director = "Howard Hawks",
                    MainCast = "John Wayne, Dean Martin, Ricky Nelson",
                    Synopsis = "A small-town sheriff in the American West enlists the help of a cripple, a drunk, and a young gunfighter in his efforts to hold in jail the brother of the local bad guy.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/rio-bravo.jpeg"
                },
                new Movie
                {
                    Title = "Spirited Away",
                    ReleaseDate = DateTime.Parse("2001-7-20"),
                    Genre = "Animation",
                    Price = 7.99M,
                    Rating = "R",
                    Director = "Hayao Miyazaki",
                    MainCast = "Rumi Hiiragi, Miyu Irino",
                    Synopsis = "During her family's move to the suburbs, a sullen 10-year-old girl wanders into a world ruled by gods, witches, and spirits, and where humans are changed into beasts.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/spirited-away.jpeg"
                },
                new Movie
                {
                    Title = "Seven Samurai",
                    ReleaseDate = DateTime.Parse("1954-4-26"),
                    Genre = "History",
                    Price = 8.99M,
                    Rating = "G",
                    Director = "Akira Kurosawa",
                    MainCast = "Toshiro Mifune, Takashi Shimura",
                    Synopsis = "A poor village under attack by bandits recruits seven unemployed samurai to help them defend themselves.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/seven-samurai.jpeg"
                },
                new Movie
                {
                    Title = "The Legend of 1900",
                    ReleaseDate = DateTime.Parse("1910-10-28"),
                    Genre = "Fiction",
                    Price = 9.99M,
                    Rating = "G",
                    Director = "Giuseppe Tornatore",
                    MainCast = "Tim Roth, Pruitt Taylor Vince",
                    Synopsis = "A baby boy, discovered in 1900 on an ocean liner, grows into a musical prodigy, never setting foot on land.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/the-legend-of-1900.jpeg"
                },
                new Movie
                {
                    Title = "Titanic",
                    ReleaseDate = DateTime.Parse("1997-12-19"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "NA",
                    Director = "James Cameron",
                    MainCast = "Leonardo DiCaprio, Kate Winslet",
                    Synopsis = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                    PosterImageUrl = "https://movieposter.blob.core.windows.net/poster/titanic.jpeg"
                },
                // new Movie
                // {
                //     Title = "The Shawshank Redemption",
                //     ReleaseDate = DateTime.Parse("1994-09-23"),
                //     Genre = "Drama",
                //     Price = 8.99M,
                //     Rating = "R",
                //     Director = "Frank Darabont",
                //     MainCast = "Tim Robbins, Morgan Freeman",
                //     Synopsis = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
                // },
                // new Movie
                // {
                //     Title = "Inception",
                //     ReleaseDate = DateTime.Parse("2010-07-16"),
                //     Genre = "Sci-Fi/Action",
                //     Price = 11.99M,
                //     Rating = "PG-13",
                //     Director = "Christopher Nolan",
                //     MainCast = "Leonardo DiCaprio, Joseph Gordon-Levitt",
                //     Synopsis = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O."
                // },
                // new Movie
                // {
                //     Title = "The Godfather",
                //     ReleaseDate = DateTime.Parse("1972-03-24"),
                //     Genre = "Crime/Drama",
                //     Price = 7.99M,
                //     Rating = "R",
                //     Director = "Francis Ford Coppola",
                //     MainCast = "Marlon Brando, Al Pacino",
                //     Synopsis = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
                // },
                // new Movie
                // {
                //     Title = "Pulp Fiction",
                //     ReleaseDate = DateTime.Parse("1994-10-14"),
                //     Genre = "Crime/Drama",
                //     Price = 8.99M,
                //     Rating = "R",
                //     Director = "Quentin Tarantino",
                //     MainCast = "John Travolta, Uma Thurman, Samuel L. Jackson",
                //     Synopsis = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption."
                // },
                // new Movie
                // {
                //     Title = "The Dark Knight",
                //     ReleaseDate = DateTime.Parse("2008-07-18"),
                //     Genre = "Action/Crime",
                //     Price = 10.99M,
                //     Rating = "PG-13",
                //     Director = "Christopher Nolan",
                //     MainCast = "Christian Bale, Heath Ledger",
                //     Synopsis = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice."
                // },
                // new Movie
                // {
                //     Title = "Forrest Gump",
                //     ReleaseDate = DateTime.Parse("1994-07-06"),
                //     Genre = "Drama/Romance",
                //     Price = 8.99M,
                //     Rating = "PG-13",
                //     Director = "Robert Zemeckis",
                //     MainCast = "Tom Hanks, Robin Wright",
                //     Synopsis = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart."
                // },
                // new Movie
                // {
                //     Title = "The Matrix",
                //     ReleaseDate = DateTime.Parse("1999-03-31"),
                //     Genre = "Sci-Fi/Action",
                //     Price = 9.99M,
                //     Rating = "R",
                //     Director = "The Wachowskis",
                //     MainCast = "Keanu Reeves, Laurence Fishburne",
                //     Synopsis = "A computer programmer discovers that reality as he knows it is a simulation created by machines to subjugate humanity, and joins a rebellion to overthrow them."
                // },
                // new Movie
                // {
                //     Title = "Schindler's List",
                //     ReleaseDate = DateTime.Parse("1993-12-15"),
                //     Genre = "Biography/Drama",
                //     Price = 7.99M,
                //     Rating = "R",
                //     Director = "Steven Spielberg",
                //     MainCast = "Liam Neeson, Ben Kingsley",
                //     Synopsis = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis."
                // },
                // new Movie
                // {
                //     Title = "Goodfellas",
                //     ReleaseDate = DateTime.Parse("1990-09-19"),
                //     Genre = "Biography/Crime",
                //     Price = 8.99M,
                //     Rating = "R",
                //     Director = "Martin Scorsese",
                //     MainCast = "Robert De Niro, Ray Liotta, Joe Pesci",
                //     Synopsis = "The story of Henry Hill and his life in the mob, covering his relationship with his wife Karen Hill and his mob partners Jimmy Conway and Tommy DeVito in the Italian-American crime syndicate."
                // }
        };
    }
}