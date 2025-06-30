using System;
using Xunit;
using Infrastructure.Services;
using Domain.Entities;
using System.Linq;

namespace Tests
{
    public class MultimediaServiceTests
    {
        [Fact]
        public void Admin_Can_Add_And_Delete_Movie()
        {
            var service = new MultimediaService();
            service.SetCurrentRole("Admin");
            var movie = new Movie { Title = "Test Movie", Director = "Test Director", Year = 2024 };
            var added = service.AddMovie(movie);
            Assert.NotNull(added);
            Assert.True(service.GetAllMovies().Any(m => m.Title == "Test Movie"));
            Assert.True(service.DeleteMovie(added.Id));
        }

        [Fact]
        public void User_Cannot_Add_Or_Delete_Movie()
        {
            var service = new MultimediaService();
            service.SetCurrentRole("User");
            var movie = new Movie { Title = "Test Movie", Director = "Test Director", Year = 2024 };
            Assert.Throws<UnauthorizedAccessException>(() => service.AddMovie(movie));
            Assert.Throws<UnauthorizedAccessException>(() => service.DeleteMovie(1));
        }

        [Fact]
        public void Moderator_Can_Update_Book()
        {
            var service = new MultimediaService();
            service.SetCurrentRole("Moderator");
            var book = service.GetAllBooks().First();
            book.Title = "Updated Title";
            var updated = service.UpdateBook(book);
            Assert.Equal("Updated Title", updated.Title);
        }

        [Fact]
        public void User_Can_View_Books_But_Cannot_Update()
        {
            var service = new MultimediaService();
            service.SetCurrentRole("User");
            var books = service.GetAllBooks();
            Assert.NotEmpty(books);
            var book = books.First();
            book.Title = "Should Not Update";
            Assert.Throws<UnauthorizedAccessException>(() => service.UpdateBook(book));
        }

        [Fact]
        public void Admin_Can_Add_And_Delete_Game()
        {
            var service = new MultimediaService();
            service.SetCurrentRole("Admin");
            var game = new Game { Title = "Test Game", Developer = "Test Dev", Year = 2025 };
            var added = service.AddGame(game);
            Assert.NotNull(added);
            Assert.True(service.GetAllGames().Any(g => g.Title == "Test Game"));
            Assert.True(service.DeleteGame(added.Id));
        }
    }
}
