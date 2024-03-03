namespace BookService.Data
{
    public record BookLibrary
    {
        private List<Book> AvailableBooks;

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
        }

        public int GetBookPrice(Book neededBook)
        {
            Book? foundedBook = (from book in AvailableBooks
                                 where (book.Name == neededBook.Name && book.Author == neededBook.Author &&
                                        book.PublishYear == neededBook.PublishYear)
                                 select book).FirstOrDefault();
            return foundedBook?.Price ?? 0;
        }
    }
}