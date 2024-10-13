
using Domain;
using Domain.Repositories;
using Persistence.Context;
using Service.UnitOfWork.Generic;

namespace Service.Repositories
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
