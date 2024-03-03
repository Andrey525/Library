namespace FilmService.Data
{
    public record FilmLibrary
    {
        private List<Film> AvailableFilms;

        /*Mock constructor*/
        public FilmLibrary()
        {
            Console.WriteLine("BookLibrary created");
            AvailableFilms = new List<Film>
            {
                new Film
                {
                    Name = "The Witcher. The Last Wish",
                    Producer = "Netflix",
                    ReleaseDate = new DateOnly(2017, 11, 5),
                    Price = 10
                },
                new Film
                {
                    Name = "The Witcher. Blood of Elves",
                    Producer = "Netflix",
                    ReleaseDate = new DateOnly(2018, 12, 17),
                    Price = 12
                },
                new Film
                {
                    Name = "The Witcher. The Lady of the Lake",
                    Producer = "Netflix",
                    ReleaseDate = new DateOnly(2013, 3, 15),
                    Price = 18
                }
            };
        }

        public int GetFilmPrice(Film neededFilm)
        {
            Film? foundedFilm = (from film in AvailableFilms
                                 where (film.Name == neededFilm.Name && film.Producer == neededFilm.Producer &&
                                        film.ReleaseDate == neededFilm.ReleaseDate)
                                 select film).FirstOrDefault();
            return foundedFilm?.Price ?? 0;
        }
    }
}