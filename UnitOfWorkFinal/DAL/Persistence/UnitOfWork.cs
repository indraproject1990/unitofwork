
using BOL;
using BOL.Core;
using BOL.Core.Repository.DAL;
using DAL.Persistence.Repository;
using System.Data.Entity;

namespace DAL.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopEntities _context;

        public UnitOfWork(ShopEntities context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Admins = new AdminRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IAdminRepository Admins { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}