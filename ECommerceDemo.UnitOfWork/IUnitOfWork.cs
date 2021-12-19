using ECommerceDemo.Repository;
using System;

namespace ECommerceDemo.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEcommerceRepository EcommerceRepository { get; }
    }
}
