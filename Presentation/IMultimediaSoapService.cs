using CoreWCF;
using System.Collections.Generic;
using Domain.Entities;

namespace Presentation.Services
{
    [ServiceContract]
    public interface IMultimediaSoapService
    {
        [OperationContract]
        Movie AddMovie(Movie movie);
        [OperationContract]
        bool DeleteMovie(int id);
        [OperationContract]
        Movie UpdateMovie(Movie movie);
        [OperationContract]
        Movie GetMovie(int id);
        [OperationContract]
        List<Movie> GetAllMovies();
        [OperationContract]
        Book AddBook(Book book);
        [OperationContract]
        bool DeleteBook(int id);
        [OperationContract]
        Book UpdateBook(Book book);
        [OperationContract]
        Book GetBook(int id);
        [OperationContract]
        List<Book> GetAllBooks();
        [OperationContract]
        Game AddGame(Game game);
        [OperationContract]
        bool DeleteGame(int id);
        [OperationContract]
        Game UpdateGame(Game game);
        [OperationContract]
        Game GetGame(int id);
        [OperationContract]
        List<Game> GetAllGames();
    }
}
