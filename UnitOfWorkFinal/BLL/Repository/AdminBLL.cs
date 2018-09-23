using BOL;
using DAL.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository
{
    public class AdminBLL : IDisposable
    {
        public AdminTB AdminLogin(AdminTB model)
        {
            try
            {
                string username = model.Username;
                string password = model.Password;
                using (var _unitOfWork = new UnitOfWork(new ShopEntities()))
                {
                    
                    AdminTB admin = _unitOfWork.Admins.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password && x.IsActive == true);
                    return admin;
                }
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
