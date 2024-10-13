using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Domain.UnitOfWork.Generic;

namespace Domain.Repositories
{
    public interface IAddressRepository : IGenericRepository<Place>
    {
    }
}
