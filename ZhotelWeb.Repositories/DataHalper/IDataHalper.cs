using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhotelWeb.Repositories.DataHalper
{
    public interface IDataHalper<Table>
    {
        Task Add(Table table);
        Task<Table> GetById(int id);
        Task Update(Table table);
        Task Delete(int id);
        Task<List<Table>> GetAll();

    }
}
