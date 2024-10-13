using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Repository.UnitOfWork.Generic.Base;

namespace Repository.Interfaces
{
    public interface IAddressRepository : IGenericRepository<Place>
    {
    }
}
