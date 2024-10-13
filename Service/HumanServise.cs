using Domain;
using Domain.Repositories;
using Domain.UnitOfWork;

namespace Service
{
    public class HumanServise
    {
        IUnitOfWork _unitOfWork;
        IHumanRepository _repository;

        public HumanServise(IUnitOfWork unitOfWork, IHumanRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual void Create(Human entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Insert(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(Human entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(Human entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Human>> GetAll()
        {
            return await _repository.GetAll();
        }
    }
}
