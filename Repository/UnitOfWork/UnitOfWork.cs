using Data.Context;
using Repository.Interfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyContext _context ;
        private IHumanRepository? _humanRepository;
        private IImageRepository? _imageRepository;
        private IAddressRepository? _addressRepository;

        public UnitOfWork(MyContext context)
        {
            _context = context;
        }

        public IHumanRepository HumanRepository
        {
            get
            {

                if (this._humanRepository == null)
                {
                    _humanRepository = new HumanRrepository(_context);
                }
                return _humanRepository;
            }
        }
        public IImageRepository ImageRepository
        {
            get
            {

                if (this._imageRepository == null)
                {
                    _imageRepository = new ImageRepository(_context);
                }
                return _imageRepository;
            }
        }
        public IAddressRepository AddressRepository
        {
            get
            {
                if (this._addressRepository == null)
                {
                    _addressRepository = new AddressRepository(_context);
                }
                return _addressRepository;
            }
        }
        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() >0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
