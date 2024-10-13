using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IHumanRepository HumanRepository { get; }
        IAddressRepository AddressRepository { get; }
        IImageRepository ImageRepository { get; }
        Task<bool> Commit();
    }
}
