using Domain;
using Domain.Repositories;
using Persistence.Context;
using Service.UnitOfWork.Generic;

namespace Service.Repositories
{
    public class ImageRepository : GenericRepository<Img>, IImageRepository
    {
        public ImageRepository(MyContext context) : base(context)
        {

        }
    }
}
