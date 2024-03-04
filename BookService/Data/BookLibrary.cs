namespace BookService.Data
{
    public record BookLibrary
    {
        public List<Book> AvailableBooks { get; }
        private List<Book>? _mockBooks;

        public BookLibrary()
        {
            Console.WriteLine("BookLibrary created");
            Random random = new Random();
            InitMockBooks();
            AvailableBooks = new List<Book>();
            if (_mockBooks?.Count > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    AvailableBooks.Add(_mockBooks[random.Next(0, _mockBooks.Count)]);
                }
            }
            var timerAdd = new Timer((_) => { AddBook(); }, null, 0, 5000);
            var timerDelete = new Timer((_) => { DeleteBook(); }, null, 0, 6000);
        }

        public int GetBookPrice(Book neededBook)
        {
            Book? foundedBook = (from book in AvailableBooks
                                 where (book.Name == neededBook.Name && book.Author == neededBook.Author &&
                                        book.PublishYear == neededBook.PublishYear)
                                 select book).FirstOrDefault();
            return foundedBook?.Price ?? 0;
        }

        private void AddBook()
        {
            if (_mockBooks == null || _mockBooks.Count <= 0)
            {
                return;
            }
            Random random = new Random();
            AvailableBooks.Add(_mockBooks[random.Next(0, _mockBooks.Count)]);
        }

        private void DeleteBook()
        {
            if (AvailableBooks.Count == 0)
                return;

            Random random = new Random();
            AvailableBooks.RemoveAt(random.Next(0, AvailableBooks.Count));
        }

        private void InitMockBooks()
        {
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