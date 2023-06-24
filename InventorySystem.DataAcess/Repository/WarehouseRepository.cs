using InventorySystem.DataAccess.Data;
using InventorySystem.DataAcess.Repository.IRepository;
using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataAcess.Repository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private readonly ApplicationDbContext _db;
        public WarehouseRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void Update(Warehouse warehouse)
        {
            var warehouseBD = _db.Warehouses.FirstOrDefault(b => b.Id == warehouse.Id);
            if (warehouseBD != null)
            {
                warehouseBD.Name = warehouse.Name;
                warehouseBD.Description = warehouse.Description;
                warehouseBD.State = warehouse.State;
                _db.SaveChanges();
            }
        }
    }
}
