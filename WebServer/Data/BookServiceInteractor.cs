using BookService;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace WebServer.Data
{
    public class BookServiceInteractor
    {
        public BookServ.BookServClient Client { get; private init; }

        public BookServiceInteractor(BookServ.BookServClient client)
        {
            Client = client;
        }

        public async Task<List<GetBookReply>?> GetBooksAsync()
        {
            Console.WriteLine("GetBooksAsync");
            var getBookReplies = new List<GetBookReply>();
            try
            {
                using var call = Client.GetBooks(new Empty());
                await foreach (var message in call.ResponseStream.ReadAllAsync())
                {
                    getBookReplies.Add(message);
                }
                //await Task.Delay(2000); //!!!
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return getBookReplies;
        }

        public async Task<int> GetBookPriceAsync(GetBookReply book)
        {
            var reply = await Client.GetBookPriceAsync(new GetBookPriceRequest()
            {
                BookName = book.BookName,
                AuthorName = book.AuthorName,
                PublishYear = book.PublishYear
            });
            //await Task.Delay(2000);
            return reply.Price;
        }
    }
}