using InventorySystem.DataAccess.Data;
using InventorySystem.DataAcess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public IWarehouseRepository Warehouse { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Warehouse = new WarehouseRepository(_db);
        }
  

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
