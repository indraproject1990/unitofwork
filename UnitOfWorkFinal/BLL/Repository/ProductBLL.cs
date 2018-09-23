using BOL;
using BOL.Core;
using BOL.Core.Repository.BLL;
using DAL.Persistence;
using DAL.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class ProductBLL : IProductBusiness,IDisposable
    {
        public IEnumerable<Product> ActiveProductList()
        {
            using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
            {
                List<Product> products = _unitOfWork.Products.GetAll(x => x.InStock == true).ToList();
                return products;
            }
        }
        public IEnumerable<Product> GetAllProduct()
        {
            try
            {
                using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
                {
                    List<Product> products = _unitOfWork.Products.GetAll().Select(s => new Product { Id = s.Id, Name = s.Name, Price = s.Price, InStock = s.InStock }).ToList();
                    return products;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
        public long AddEditProduct(Product product)
        {
            try
            {
                using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
                {
                    if (product.Id == 0)
                    {
                        Product obj = new Product
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Price = product.Price,
                            InStock = true
                        };
                        _unitOfWork.Products.Insert(obj);

                        _unitOfWork.Complete();
                        return obj.Id;
                    }
                    else
                    {
                        Product obj = _unitOfWork.Products.SingleOrDefault(x => x.Id == product.Id);
                        if (obj != null)
                        {
                            obj.Id = product.Id;
                            obj.Name = product.Name;
                            obj.Price = product.Price;

                        }
                        _unitOfWork.Complete();
                        return obj.Id;
                    }
                }

            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }
        public Product GetProductById(long? id)
        {
            using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
            {
                return _unitOfWork.Products.SingleOrDefault(x => x.Id == id);
            }
        }
        public int DeleteProduct(long? id)
        {
            try
            {
                using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
                {
                    _unitOfWork.Products.Delete(x => x.Id == id);
                    _unitOfWork.Complete();
                    return 1;
                }
            }
            catch (Exception)
            {
                return 0;
                throw;
            }

        }

        public bool ChangeProductStatus(long? id)
        {
            try
            {
                using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
                {
                    var obj = _unitOfWork.Products.SingleOrDefault(x => x.Id == id);
                    if (obj != null && obj.InStock == true)
                    {
                        obj.InStock = false;
                        _unitOfWork.Complete();
                        return false;
                    }
                    else if (obj != null)
                    {
                        obj.InStock = true;
                        _unitOfWork.Complete();
                        return true;
                    }

                    
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
