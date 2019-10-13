using System;

namespace Base.Architecture.UserManagement.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
