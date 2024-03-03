namespace BookService.Data
{
    public record BookLibrary
    {
        public List<Book> AvailableBooks { get; }

        /*Mock constructor*/
        public BookLibrary()
        {
            Console.WriteLine("BookLibrary created");
            AvailableBooks = new List<Book>
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
                }
            };

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
            Random random = new Random();
            AvailableBooks.Add(new Book()
            {
                Author = random.Next().ToString(),
                Name = random.Next().ToString(),
                PublishYear = random.Next(),
                Price = random.Next()
            });
        }

        private void DeleteBook()
        {
            if (AvailableBooks.Count == 0)
                return;

            Random random = new Random();
            AvailableBooks.RemoveAt(random.Next(0, AvailableBooks.Count));
        }
    }
}