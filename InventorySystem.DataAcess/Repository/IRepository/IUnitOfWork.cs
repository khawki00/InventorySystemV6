using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAcess.Repository.IRepository
{
    public  interface IUnitOfWork : IDisposable
    {
        IWarehouseRepository Warehouse { get; }
        Task Save();
    }
}
