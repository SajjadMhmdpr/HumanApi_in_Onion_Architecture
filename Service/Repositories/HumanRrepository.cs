using Domain;
using Domain.Repositories;
using Persistence.Context;
using Service.UnitOfWork.Generic;

namespace Service.Repositories
{
    public class HumanRrepository : GenericRepository<Human>, IHumanRepository
    {

        public HumanRrepository(MyContext context) : base(context)
        {

        }


    }
}
