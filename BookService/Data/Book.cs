namespace BookService.Data
{
    public record Book
    {
        public string Name { get; init; }
        public string Author { get; init; }
        public int PublishYear { get; init; }
        public int Price { get; set; }
    }
}