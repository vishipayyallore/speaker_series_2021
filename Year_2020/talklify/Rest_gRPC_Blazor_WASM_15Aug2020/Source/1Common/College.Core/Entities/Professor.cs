using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Core.Entities
{

    public class Professor
    {
        [Key]
        public Guid ProfessorId { get; set; }

        public string Name { get; set; }

        public DateTime Doj { get; set; }

        public string Teaches { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }

        public bool IsPhd { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }

}
