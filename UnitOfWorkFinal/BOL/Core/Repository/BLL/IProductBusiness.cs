using BOL.Core.Repository.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL.Core.Repository.BLL
{
    public interface IProductBusiness
    {
        IEnumerable<Product> ActiveProductList();
        IEnumerable<Product> GetAllProduct();
        long AddEditProduct(Product product);
        Product GetProductById(long? id);
        int DeleteProduct(long? id);
        bool ChangeProductStatus(long? id);
    }
}
