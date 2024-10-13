using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repositories;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IHumanRepository HumanRepository { get; }
        IAddressRepository AddressRepository { get; }
        IImageRepository ImageRepository { get; }
        Task<bool> Commit();
    }
}
