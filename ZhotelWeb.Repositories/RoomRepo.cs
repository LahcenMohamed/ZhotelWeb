using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHotelWeb.Models;
using ZhotelWeb.Repositories.DataHalper;
namespace ZhotelWeb.Repositories
{
    public class RoomRepo : IRoomHalper
    {
        private readonly ZHotelDbContext zHotelDbContext;

        public RoomRepo(ZHotelDbContext zHotelDbContext)
        {
            this.zHotelDbContext = zHotelDbContext;
        }
        public async Task Add(Room table)
        {
            zHotelDbContext.Rooms.Add(table);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Room room = await GetById(id);
            zHotelDbContext.Rooms.Remove(room);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task<List<Room>> GetAll()
        {
            List<Room> rooms = await zHotelDbContext.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> GetById(int id)
        {
            Room room = await zHotelDbContext.Rooms.Include(x => x.Reviews).Include(x => x.Reservations).FirstOrDefaultAsync(z => z.Id == id);
            return room;
        }

        public async Task Update(Room table)
        {
            zHotelDbContext.Rooms.Update(table);
            await zHotelDbContext.SaveChangesAsync();
        }
    }
}
