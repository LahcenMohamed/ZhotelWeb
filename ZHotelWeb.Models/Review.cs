using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }
        public decimal assessment { get; set; }
        public string Discrition { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
    }
}
