using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

namespace ZhotelWeb.Repositories
{
    public class ReservationRepo : IReservationHalper
    {
        private readonly ZHotelDbContext zHotelDbContext;

        public ReservationRepo(ZHotelDbContext zHotelDbContext)
        {
            this.zHotelDbContext = zHotelDbContext;
        }
        public async Task Add(Reservation table)
        {
            zHotelDbContext.Reservations.Add(table);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Reservation reservation = await GetById(id);
            zHotelDbContext.Reservations.Remove(reservation);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetAll()
        {
            List<Reservation> reservations = await zHotelDbContext.Reservations.Include(x => x.Room).Include(x => x.Customer).ToListAsync();
            return reservations;
        }

        public async Task<Reservation> GetById(int id)
        {
            Reservation reservation = await zHotelDbContext.Reservations.FindAsync(id);
            return reservation;
        }

        public async Task Update(Reservation table)
        {
            zHotelDbContext.Reservations.Update(table);
            await zHotelDbContext.SaveChangesAsync();
        }
    }
}
