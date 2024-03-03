using FilmService.Data;
using Grpc.Core;
using Microsoft.AspNetCore.Components;

namespace FilmService.Services
{
    public class FilmService : FilmServ.FilmServBase
    {
        [Inject] FilmLibrary Library { get; }

        private readonly ILogger<FilmService> _logger;

        public FilmService(ILogger<FilmService> logger, FilmLibrary library)
        {
            _logger = logger;
            Library = library;
        }

        public override Task<GetFilmPriceReply> GetFilmPrice(GetFilmPriceRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetFilmPriceReply()
            {
                Price = Library.GetFilmPrice(new Film()
                {
                    Name = request.FilmName,
                    Producer = request.ProducerName,
                    ReleaseDate = DateOnly.FromDateTime(request.ReleaseDate.ToDateTime())
                })
            });
        }
    }
}