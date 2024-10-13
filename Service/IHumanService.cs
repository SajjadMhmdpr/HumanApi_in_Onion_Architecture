
using Domain;

namespace Service
{
    public interface IHumanService
    {
        void Create(Human entity);
        void Delete(Human entity);
        IEnumerable<Human> GetAll();
        void Update(Human entity);
    }
}
