using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime DateOfArrival { get; set; }
        public DateTime DateOfDeparture { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
    }
}
