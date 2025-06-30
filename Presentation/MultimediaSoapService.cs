using System.Collections.Generic;
using System.Linq;
using CoreWCF;
using Domain.Entities;
using Infrastructure.Services;

namespace Presentation.Services
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class MultimediaSoapService : IMultimediaSoapService
    {
        private readonly MultimediaService _service = new();
        public Movie AddMovie(Movie movie) => _service.AddMovie(movie);
        public bool DeleteMovie(int id) => _service.DeleteMovie(id);
        public Movie UpdateMovie(Movie movie) => _service.UpdateMovie(movie);
        public Movie GetMovie(int id) => _service.GetMovie(id);
        public List<Movie> GetAllMovies() => _service.GetAllMovies().ToList();
        public Book AddBook(Book book) => _service.AddBook(book);
        public bool DeleteBook(int id) => _service.DeleteBook(id);
        public Book UpdateBook(Book book) => _service.UpdateBook(book);
        public Book GetBook(int id) => _service.GetBook(id);
        public List<Book> GetAllBooks() => _service.GetAllBooks().ToList();
        public Game AddGame(Game game) => _service.AddGame(game);
        public bool DeleteGame(int id) => _service.DeleteGame(id);
        public Game UpdateGame(Game game) => _service.UpdateGame(game);
        public Game GetGame(int id) => _service.GetGame(id);
        public List<Game> GetAllGames() => _service.GetAllGames().ToList();
    }
}
