using BookService.Data;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Components;

namespace BookService.Services
{
    public class BookService : BookServ.BookServBase
    {
        private readonly ILogger<BookService> _logger;

        [Inject] BookLibrary Library { get; }

        public BookService(ILogger<BookService> logger, BookLibrary library)
        {
            _logger = logger;
            Library = library;
        }

        public override Task<GetBookPriceReply> GetBookPrice(GetBookPriceRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetBookPriceReply
            {
                Price = Library.GetBookPrice(new Book
                {
                    Name = request.BookName,
                    Author = request.AuthorName,
                    PublishYear = request.PublishYear,
                })
            });
        }

        public override async Task GetBooks(Empty request, IServerStreamWriter<GetBookReply> responseStream,
            ServerCallContext context)
        {
            Console.WriteLine("GetBooks");
            foreach (var book in Library.AvailableBooks)
            {
                await responseStream.WriteAsync(new GetBookReply()
                { BookName = book.Name, AuthorName = book.Author, PublishYear = book.PublishYear });
            }
        }
    }
}