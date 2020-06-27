using System;
using System.ComponentModel.DataAnnotations;

namespace College.ApplicationCore.Entities
{

    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public string FullAddress { get; set; }

        public string Enrollment { get; set; }

        public string EnrollmentStatus { get; set; }
    }

}
