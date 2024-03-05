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
            var neededFilm = new Film()
            {
                Name = request.FilmName,
                Studio = request.StudioName,
                ReleaseDate = DateOnly.FromDateTime(request.ReleaseDate.ToDateTime())
            };

            var priceMap = Library.GetFilmPrice(neededFilm);

            var getFilmPriceReply = new GetFilmPriceReply();
            getFilmPriceReply.Price.Add(priceMap);

            return Task.FromResult(getFilmPriceReply);
        }
    }
}