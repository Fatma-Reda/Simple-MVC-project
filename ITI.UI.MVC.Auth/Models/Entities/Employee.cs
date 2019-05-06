using ITI.UI.MVC.Auth.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ITI.UI.MVC.Auth.Models.Entities
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name="Full Name")]
        public string Name { get; set; }
        [Required]
        [Range(25, 100)]
        public int Age { get; set; }
        public Gender Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int FK_depId { get; set; }
        public Department Department { get; set; }
    }
}