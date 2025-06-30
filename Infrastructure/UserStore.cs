using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure
{
    public static class UserStore
    {
        public static List<User> Users = new List<User>
        {
            new User { Id = 1, Username = "admin", PasswordHash = "admin", Role = "Admin" },
            new User { Id = 2, Username = "moderator", PasswordHash = "moderator", Role = "Moderator" },
            new User { Id = 3, Username = "user", PasswordHash = "user", Role = "User" }
        };
    }
}
