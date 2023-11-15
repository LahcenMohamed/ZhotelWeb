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
    public class StaffRepo : IStaffHalper
    {
        private readonly ZHotelDbContext zHotelDbContext;

        public StaffRepo(ZHotelDbContext zHotelDbContext)
        {
            this.zHotelDbContext = zHotelDbContext;
        }
        public async Task Add(Staff table)
        {
            zHotelDbContext.Staffs.Add(table);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Staff staff = await GetById(id);
            zHotelDbContext.Staffs.Remove(staff);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task<List<Staff>> GetAll()
        {
            List<Staff> staffs = await zHotelDbContext.Staffs.ToListAsync();
            return staffs;
        }

        public async Task<Staff> GetById(int id)
        {
            Staff staff = await zHotelDbContext.Staffs.FindAsync(id);
            return staff;
        }

        public async Task Update(Staff table)
        {
            zHotelDbContext.Staffs.Update(table);
            await zHotelDbContext.SaveChangesAsync();
        }
    }
}
