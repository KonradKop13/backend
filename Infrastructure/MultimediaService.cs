using System.Collections.Generic;
using Application.Interfaces;
using Domain.Entities;
using Application.Authorization;

namespace Infrastructure.Services
{
    public class MultimediaService : IMultimediaService
    {
        private readonly List<Movie> _movies = new();
        private readonly List<Book> _books = new();
        private readonly List<Game> _games = new();
        private readonly List<User> _users = new()
        {
            new User { Id = 1, Username = "admin", PasswordHash = "admin", Role = "Admin" },
            new User { Id = 2, Username = "moderator", PasswordHash = "moderator", Role = "Moderator" },
            new User { Id = 3, Username = "user", PasswordHash = "user", Role = "User" }
        };
        private readonly List<Rating> _ratings = new()
        {
            new Rating { Id = 1, UserId = 1, MovieId = 1, Value = 9 },
            new Rating { Id = 2, UserId = 2, BookId = 1, Value = 8 },
            new Rating { Id = 3, UserId = 3, GameId = 1, Value = 7 }
        };
        private int _movieId = 1, _bookId = 1, _gameId = 1;
        private string _currentRole = "Admin";

        public MultimediaService() {
            _movies.Add(new Movie { Id = _movieId++, Title = "Inception", Director = "Christopher Nolan", Year = 2010 });
            _movies.Add(new Movie { Id = _movieId++, Title = "The Matrix", Director = "Wachowski Sisters", Year = 1999 });
            _books.Add(new Book { Id = _bookId++, Title = "1984", Author = "George Orwell", Year = 1949 });
            _books.Add(new Book { Id = _bookId++, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 });
            _games.Add(new Game { Id = _gameId++, Title = "The Witcher 3", Developer = "CD Projekt", Year = 2015 });
            _games.Add(new Game { Id = _gameId++, Title = "Portal 2", Developer = "Valve", Year = 2011 });
        }

        public void SetCurrentRole(string role)
        {
            _currentRole = role;
        }

        public Movie AddMovie(Movie movie)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Add"))
                throw new UnauthorizedAccessException("Insufficient permissions to add movie.");
            movie.Id = _movieId++;
            _movies.Add(movie);
            return movie;
        }
        public bool DeleteMovie(int id)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Delete"))
                throw new UnauthorizedAccessException("Insufficient permissions to delete movie.");
            return _movies.RemoveAll(m => m.Id == id) > 0;
        }
        public Movie? UpdateMovie(Movie movie)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Update"))
                throw new UnauthorizedAccessException("Insufficient permissions to update movie.");
            var existing = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existing == null) return null;
            existing.Title = movie.Title;
            existing.Director = movie.Director;
            existing.Year = movie.Year;
            return existing;
        }
        public Movie? GetMovie(int id) => _movies.FirstOrDefault(m => m.Id == id);
        public IEnumerable<Movie> GetAllMovies() => _movies;

        public Book AddBook(Book book)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Add"))
                throw new UnauthorizedAccessException("Insufficient permissions to add book.");
            book.Id = _bookId++;
            _books.Add(book);
            return book;
        }
        public bool DeleteBook(int id)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Delete"))
                throw new UnauthorizedAccessException("Insufficient permissions to delete book.");
            return _books.RemoveAll(b => b.Id == id) > 0;
        }
        public Book? UpdateBook(Book book)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Update"))
                throw new UnauthorizedAccessException("Insufficient permissions to update book.");
            var existing = _books.FirstOrDefault(b => b.Id == book.Id);
            if (existing == null) return null;
            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Year = book.Year;
            return existing;
        }
        public Book? GetBook(int id) => _books.FirstOrDefault(b => b.Id == id);
        public IEnumerable<Book> GetAllBooks() => _books;

        public Game AddGame(Game game)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Add"))
                throw new UnauthorizedAccessException("Insufficient permissions to add game.");
            game.Id = _gameId++;
            _games.Add(game);
            return game;
        }
        public bool DeleteGame(int id)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Delete"))
                throw new UnauthorizedAccessException("Insufficient permissions to delete game.");
            return _games.RemoveAll(g => g.Id == id) > 0;
        }
        public Game? UpdateGame(Game game)
        {
            if (!RoleAuthorization.HasPermission(_currentRole, "Update"))
                throw new UnauthorizedAccessException("Insufficient permissions to update game.");
            var existing = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existing == null) return null;
            existing.Title = game.Title;
            existing.Developer = game.Developer;
            existing.Year = game.Year;
            return existing;
        }
        public Game? GetGame(int id) => _games.FirstOrDefault(g => g.Id == id);
        public IEnumerable<Game> GetAllGames() => _games;
    }
}
