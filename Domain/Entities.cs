namespace Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int Year { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public int Year { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Developer { get; set; }
        public int Year { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Role { get; set; }
    }

    public class Rating
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? MovieId { get; set; }
        public int? BookId { get; set; }
        public int? GameId { get; set; }
        public int Value { get; set; }
    }
}
