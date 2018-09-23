using BOL;
using BOL.Core.Repository.DAL;
using DAL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Persistence.Repository
{
    public class AdminRepository : Repository<AdminTB>, IAdminRepository
    {

        public AdminRepository(ShopEntities context) : base(context)
        {
        }

        public ShopEntities ShopEntities
        {
            get { return Context as ShopEntities; }
        }
    }
}
