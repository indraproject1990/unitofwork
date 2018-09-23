using BOL.Core.Repository.DAL;
using System;
using System.Data.Entity;

namespace BOL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IAdminRepository Admins { get; }
        int Complete();
    }
}