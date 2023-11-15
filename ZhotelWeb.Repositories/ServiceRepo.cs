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
    public class ServiceRepo : IServiceHalper
    {
        private readonly ZHotelDbContext zHotelDbContext;

        public ServiceRepo(ZHotelDbContext zHotelDbContext)
        {
            this.zHotelDbContext = zHotelDbContext;
        }
        public async Task Add(Service table)
        {
            zHotelDbContext.Services.Add(table);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Service service = await GetById(id);
            zHotelDbContext.Services.Remove(service);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task<List<Service>> GetAll()
        {
            List<Service> services = await zHotelDbContext.Services.ToListAsync();
            return services;
        }

        public async Task<Service> GetById(int id)
        {
            Service service = await zHotelDbContext.Services.FindAsync(id);
            return service;
        }

        public async Task Update(Service table)
        {
            zHotelDbContext.Services.Update(table);
            await zHotelDbContext.SaveChangesAsync();
        }
    }
}
