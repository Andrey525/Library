using BookService.Data;
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
    }
}