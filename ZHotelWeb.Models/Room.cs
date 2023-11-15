using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Models
{
    [Table("Rooms")]
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public RoomType Type { get; set; }
        [Required]
        [Range(1,5)]
        public int BedCount { get; set; }
        [Range(1, 5)]
        public double? AvgAssessment { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsAvailabel { get; set; }
        public string? ImageUrl { get; set; }
        public List<Review>? Reviews { get; set; }
        public List<Reservation>? Reservations { get; set; }
    }
    public enum RoomType {
        Economy,
        Medium,
        Luxury
    }
}
