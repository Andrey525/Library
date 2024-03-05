namespace BookService.Data
{
    public class BookLibrary
    {
        private readonly ILogger<BookLibrary> _logger;
        public List<Book> AvailableBooks { get; }
        private List<Book>? _mockBooks;
        public SemaphoreSlim SemaphoreSlim { get; init; }

        public BookLibrary(ILogger<BookLibrary> logger)
        {
            _logger = logger;
            _logger.LogInformation("BookLibrary: new creation");

            Random random = new Random();
            SemaphoreSlim = new SemaphoreSlim(1, 1);
            InitMockBooks();
            AvailableBooks = new List<Book>();
            if (_mockBooks?.Count > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    AvailableBooks.Add(_mockBooks[random.Next(0, _mockBooks.Count)]);
                }
            }
            var timerAdd = new Timer((_) => { AddBook(); }, null, 0, 2000);
            var timerDelete = new Timer((_) => { DeleteBook(); }, null, 0, 3000);
        }

        public int GetBookPrice(Book neededBook)
        {
            SemaphoreSlim.Wait();
            Book? foundedBook = (from book in AvailableBooks
                                 where (book.Name == neededBook.Name && book.Author == neededBook.Author &&
                                        book.PublishYear == neededBook.PublishYear)
                                 select book).FirstOrDefault();
            SemaphoreSlim.Release();

            _logger.LogInformation($"GetBookPrice: {foundedBook?.Price ?? 0}");

            return foundedBook?.Price ?? 0;
        }

        private void AddBook()
        {
            if (_mockBooks == null || _mockBooks.Count <= 0)
            {
                _logger.LogError($"AddBook: no mockBooks");
                return;
            }

            SemaphoreSlim.Wait();
            Random random = new Random();
            int i = random.Next(0, _mockBooks.Count);

            _logger.LogInformation($"AddBook: addition of {_mockBooks[i]}");
            AvailableBooks.Add(_mockBooks[i]);
            SemaphoreSlim.Release();
        }

        private void DeleteBook()
        {
            SemaphoreSlim.Wait();
            if (AvailableBooks.Count == 0)
            {
                _logger.LogWarning($"DeleteBook: AvailableBooks is empty");
                return;
            }

            Random random = new Random();
            int i = random.Next(0, AvailableBooks.Count);

            _logger.LogInformation($"DeleteBook: deletion of {AvailableBooks[i]}");
            AvailableBooks.RemoveAt(i);
            SemaphoreSlim.Release();
        }

        private void InitMockBooks()
        {
            _logger.LogInformation("InitMockBooks: new mockBooks");

            _mockBooks = new List<Book>
            {
                new Book
                {
                    Name = "The Witcher. The Last Wish",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1993,
                    Price = 10
                },
                new Book
                {
                    Name = "The Witcher. Blood of Elves",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1994,
                    Price = 12
                },
                new Book
                {
                    Name = "The Witcher. The Lady of the Lake",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1999,
                    Price = 18
                },
                new Book
                {
                    Name = "The Witcher",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1990,
                    Price = 24
                },
                new Book
                {
                    Name = "The Witcher. Sword of Destiny",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1992,
                    Price = 14
                },
                new Book
                {
                    Name = "The Witcher. Time of Contempt",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1995,
                    Price = 32
                },
                new Book
                {
                    Name = "The Witcher. Baptism of Fire",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1996,
                    Price = 17
                },
                new Book
                {
                    Name = "The Witcher. The Tower of the Swallow",
                    Author = "Andrzej Sapkowski",
                    PublishYear = 1997,
                    Price = 25
                },
            };
        }
    }
}