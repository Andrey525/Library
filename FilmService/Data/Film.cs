namespace FilmService.Data
{
    public enum Resolution
    {
        Default,
        _SD360 = Default,
        _SD480,
        _HD720,
        _HD1080,
        _2K,
        _4K,
        _8K
    }
    public record Film
    {
        public string Name { get; init; }
        public string Studio { get; init; }
        public DateOnly ReleaseDate { get; init; }
        public Dictionary<Resolution, int> Price { get; init; }
    }
}