using ECommerceDemo.Repository;
using System;

namespace ECommerceDemo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IEcommerceRepository objIEcommerceRepository;
        public UnitOfWork()
        {
        }

        public IEcommerceRepository EcommerceRepository
        {
            get { return objIEcommerceRepository ?? (objIEcommerceRepository = new EcommerceRepository()); }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
