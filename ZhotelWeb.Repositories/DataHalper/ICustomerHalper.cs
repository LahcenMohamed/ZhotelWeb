using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHotelWeb.Models;

namespace ZhotelWeb.Repositories.DataHalper
{
    public interface ICustomerHalper : IDataHalper<Customer>
    {
        Task<Customer> GetByEmail(string Email);
    }
}
