using BOL;
using BOL.Core;
using BOL.Core.Repository.DAL;
using DAL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        public ProductRepository(ShopEntities context) : base(context)
        {
        }

        public ShopEntities ShopEntities
        {
            get { return Context as ShopEntities; }
        }

        public bool ChangeProductStatus(long id)
        {
            var obj = Context.Set<Product>().Where(x => x.Id == id).FirstOrDefault();
            if (obj != null && obj.InStock == true)
            {
                obj.InStock = false;
                return false;
            }
            else if (obj != null)
            {
                obj.InStock = true;
                return true;
            }
            return false;
        }
    }
}
