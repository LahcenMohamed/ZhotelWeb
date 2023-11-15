using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHotelWeb.Repository
{
    public class ZHotelDBContext : IdentityDbContext
    {
        public ZHotelDBContext(DbContextOptions<ZHotelDBContext> options) : base(options)
        {

        }
    }
}
