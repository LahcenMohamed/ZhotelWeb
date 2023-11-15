using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models
{
    [Table("Staffs")]
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(35)]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(65)]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(55)]
        public string Address { get; set; }
        [Required]
        [Range(0.00,1000000.00)]
        public decimal Salary { get; set; }
        [Required]
        [MaxLength(35)]
        public string JobName {get; set;}
        public string? ImageUrl { get; set;}
    }
}
