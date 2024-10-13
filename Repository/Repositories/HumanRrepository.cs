using Data;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.UnitOfWork.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class HumanRrepository : GenericRepository<Human>, IHumanRepository
    {

        public HumanRrepository(MyContext context) : base(context)
        {

        }


    }
}
