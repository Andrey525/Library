namespace FilmService.Data
{
    public record FilmLibrary
    {
        private List<Film> AvailableFilms { get; }
        private readonly ILogger<FilmLibrary> _logger;

        public FilmLibrary(ILogger<FilmLibrary> logger)
        {
            _logger = logger;
            _logger.LogInformation("FilmLibrary: new creation");

            Random random = new Random();
            AvailableFilms = new List<Film>()
            {
                new Film
                {
                    Name = "The Witcher. The Last Wish",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1993, 11, 5),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher. Blood of Elves",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1994, 12, 7),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher. The Lady of the Lake",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1999, 5, 7),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1990, 3, 18),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher. Sword of Destiny",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1990, 3, 18),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher. Time of Contempt",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1990, 3, 18),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher. Baptism of Fire",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1990, 3, 18),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
                new Film
                {
                    Name = "The Witcher. The Tower of the Swallow",
                    Studio = "Netflix",
                    ReleaseDate = new DateOnly(1990, 3, 18),
                    Price = new Dictionary<Resolution, int>()
                    {
                        { Resolution._SD360, 20 },
                        { Resolution._SD480, 24 },
                        { Resolution._HD720, 32 },
                        { Resolution._HD1080, 48 },
                        { Resolution._2K, 50 },
                        { Resolution._4K, 100 },
                        { Resolution._8K, 120 }
                    }
                },
            };
        }

        public Dictionary<string, int> GetFilmPrice(Film neededFilm)
        {
            Film? foundedFilm = (from film in AvailableFilms
                                 where (film.Name == neededFilm.Name && film.Studio == neededFilm.Studio &&
                                        film.ReleaseDate == neededFilm.ReleaseDate)
                                 select film).FirstOrDefault();

            if (foundedFilm == null)
                return new Dictionary<string, int>();

            var convertedPrice = new Dictionary<string, int>();
            foreach (var price in foundedFilm.Price)
            {
                convertedPrice.Add(price.Key.ToString(), price.Value);
            }

            return convertedPrice;
        }
    }
}