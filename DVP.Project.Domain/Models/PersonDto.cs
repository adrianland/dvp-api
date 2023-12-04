using System;
using System.Collections.Generic;
using DVP.Project.Domain.SeedWork;

namespace DVP.Project.Domain.Models
{
    public  class PersonDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string DocumentType { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string FullDocument { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
