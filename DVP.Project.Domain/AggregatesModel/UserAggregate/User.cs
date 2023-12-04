using System;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.Domain.AggregatesModel.UserAggregate
{
	public class User : Entity, IAggregateRoot
    {
		public User()
		{
		}

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}

