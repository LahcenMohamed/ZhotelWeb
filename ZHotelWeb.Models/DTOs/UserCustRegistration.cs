using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models.DTOs
{
    public class UserCustRegistration
    {
        [Required]
        [MaxLength(35)]
        public string UserName { get; set; }
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
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
    }
}
