# API Endpoints and User Roles Documentation

This document describes the main SOAP (CoreWCF) service endpoints and user roles for the .NET Clean Architecture multimedia rating system.

## User Roles

- **Admin**: Full access to all CRUD operations and user management.
- **Moderator**: Can manage content (CRUD on movies, books, games), but cannot manage users.
- **Regular User**: Can view and rate multimedia items, and manage their own ratings.

## Endpoints

### Movies

- `AddMovieAsync(MovieDto movie)` — Admin, Moderator
- `GetMovieAsync(int id)` — All roles
- `UpdateMovieAsync(MovieDto movie)` — Admin, Moderator
- `DeleteMovieAsync(int id)` — Admin, Moderator
- `ListMoviesAsync()` — All roles

### Books

- `AddBookAsync(BookDto book)` — Admin, Moderator
- `GetBookAsync(int id)` — All roles
- `UpdateBookAsync(BookDto book)` — Admin, Moderator
- `DeleteBookAsync(int id)` — Admin, Moderator
- `ListBooksAsync()` — All roles

### Games

- `AddGameAsync(GameDto game)` — Admin, Moderator
- `GetGameAsync(int id)` — All roles
- `UpdateGameAsync(GameDto game)` — Admin, Moderator
- `DeleteGameAsync(int id)` — Admin, Moderator
- `ListGamesAsync()` — All roles

### Ratings

- `AddRatingAsync(RatingDto rating)` — Regular User
- `GetRatingsForItemAsync(int itemId, string itemType)` — All roles
- `UpdateRatingAsync(RatingDto rating)` — Regular User (own ratings only)
- `DeleteRatingAsync(int ratingId)` — Regular User (own ratings only), Admin

### Users

- `RegisterUserAsync(UserDto user)` — All roles
- `GetUserAsync(int id)` — Admin, Moderator
- `UpdateUserAsync(UserDto user)` — Admin
- `DeleteUserAsync(int id)` — Admin
- `ListUsersAsync()` — Admin, Moderator

## Notes

- All endpoints use async/await and are exposed via CoreWCF SOAP services.
- Role-based authorization is enforced for each endpoint as described above.
- Data Transfer Objects (DTOs) are used for all service operations.
