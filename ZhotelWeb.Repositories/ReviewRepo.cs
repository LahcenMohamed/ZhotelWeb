using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHotelWeb.Models;
using ZhotelWeb.Repositories.DataHalper;

namespace ZhotelWeb.Repositories
{
    public class ReviewRepo : IReviewHalper
    {
        private readonly ZHotelDbContext zHotelDbContext;

        public ReviewRepo(ZHotelDbContext zHotelDbContext)
        {
            this.zHotelDbContext = zHotelDbContext;
        }
        public async Task Add(Review table)
        {
            zHotelDbContext.Reviews.Add(table);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Review review = await GetById(id);
            zHotelDbContext.Reviews.Remove(review);
            await zHotelDbContext.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAll()
        {
            List<Review> reviews = await zHotelDbContext.Reviews.Include(x => x.Room).Include(x => x.Customer).ToListAsync();
            return reviews;
        }

        public async Task<Review> GetById(int id)
        {
            Review review = await zHotelDbContext.Reviews.FindAsync(id);
            return review;
        }

        public async Task Update(Review table)
        {
            zHotelDbContext.Reviews.Update(table);
            await zHotelDbContext.SaveChangesAsync();
        }
    }
}
