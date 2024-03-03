namespace FilmService.Data
{
    public record Film
    {
        public string Name { get; init; }
        public string Producer { get; init; }
        public DateOnly ReleaseDate { get; init; }
        public int Price { get; set; }
    }
}