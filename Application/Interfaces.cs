using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IMultimediaService
    {
        Movie AddMovie(Movie movie);
        bool DeleteMovie(int id);
        Movie? UpdateMovie(Movie movie);
        Movie? GetMovie(int id);
        IEnumerable<Movie> GetAllMovies();
        Book AddBook(Book book);
        bool DeleteBook(int id);
        Book? UpdateBook(Book book);
        Book? GetBook(int id);
        IEnumerable<Book> GetAllBooks();
        Game AddGame(Game game);
        bool DeleteGame(int id);
        Game? UpdateGame(Game game);
        Game? GetGame(int id);
        IEnumerable<Game> GetAllGames();
    }
}
