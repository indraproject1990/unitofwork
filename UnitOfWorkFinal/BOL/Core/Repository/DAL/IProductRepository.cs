
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.Core.Repository;

namespace BOL.Core.Repository.DAL
{
    public interface IProductRepository : IRepository<Product>
    {
        bool ChangeProductStatus(long id);
    }
}
