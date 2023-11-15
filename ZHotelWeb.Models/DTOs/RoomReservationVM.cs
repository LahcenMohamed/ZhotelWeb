using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models.DTOs
{
    public class RoomReservationVM
    {
        public Room Room { get; set; }
        public Reservation Reservation { get; set; } 
        [EmailAddress]
        public string Email { get; set; }
    }
}
