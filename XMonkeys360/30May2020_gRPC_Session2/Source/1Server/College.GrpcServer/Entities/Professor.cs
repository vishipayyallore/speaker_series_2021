using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace College.Api.Entities
{
    public class Professor
    {
        [Key]
        public Guid ProfessorId { get; set; }

        public string Name { get; set; }

        public DateTime Doj { get; set; }

        public string Teaches { get; set; }

        public decimal Salary { get; set; }

        public bool IsPhd { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

    }

}
