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
    public class CustomerRepo : ICustomerHalper
    {
        private readonly ZHotelDbContext zHotelDbContext;

        public CustomerRepo(ZHotelDbContext zHotelDbContext)
        {
            this.zHotelDbContext = zHotelDbContext;
        }
        public async Task Add(Customer table)
        {
            zHotelDbContext.Customers.Add(table);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Customer customer = await GetById(id);
            zHotelDbContext.Customers.Remove(customer);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = await zHotelDbContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetByEmail(string Email)
        {
            Customer customer = await zHotelDbContext.Customers.FirstOrDefaultAsync(c => c.Email == Email);
            return customer;
        }

        public async Task<Customer> GetById(int id)
        {
            Customer customer = await zHotelDbContext.Customers.Include(c => c.Reservations).Include(c => c.Reviews).FirstOrDefaultAsync(c => c.Id == id);
            return customer;
        }

        public async Task Update(Customer table)
        {
            zHotelDbContext.Customers.Update(table);
            await zHotelDbContext.SaveChangesAsync();
        }
    }
}
