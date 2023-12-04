using System;
using System.Collections.Generic;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.Domain.Models
{
    public class UserDto : IDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
