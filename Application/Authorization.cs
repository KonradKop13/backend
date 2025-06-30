using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Application.Authorization
{
    public static class RoleAuthorization
    {
        private static readonly Dictionary<string, List<string>> Permissions = new()
        {
            { "Admin", new List<string> { "Add", "Delete", "Update", "View" } },
            { "Moderator", new List<string> { "Add", "Update", "View" } },
            { "User", new List<string> { "View" } }
        };

        public static bool HasPermission(string role, string action)
        {
            return Permissions.TryGetValue(role, out var actions) && actions.Contains(action);
        }
    }
}
