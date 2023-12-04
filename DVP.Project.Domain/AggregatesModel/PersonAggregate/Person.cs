using System;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.Domain.AggregatesModel
{
	public class Person : Entity, IAggregateRoot
    {
		public Person()
		{
		}

        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string FullDocument { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Person(string name, string lastName, string documentNumber, string documentType, string email)
        {
            Name = name;
            LastName = lastName;
            DocumentNumber = documentNumber;
            DocumentType = documentType;
            Email = email;
            FullName = name + " " + lastName;
            FullDocument = documentType + " " + documentNumber;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

    }

}