using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models
{
    [Table("Customers")]
    public class Customer
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
        public List<Review>? Reviews { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
}
