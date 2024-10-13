using Data.Context;
using Data.Entity;
using Repository.Interfaces;
using Repository.UnitOfWork.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class AddressRepository : GenericRepository<Place>, IAddressRepository
    {
        private readonly MyContext _db;
        public AddressRepository(MyContext db) : base(db)
        {
            _db = db;
        }
    }
}
