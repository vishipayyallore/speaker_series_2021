using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace College.Core.Entities
{

    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public string RollNumber { get; set; }

        public Guid ProfessorId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fees { get; set; }
    }

}
