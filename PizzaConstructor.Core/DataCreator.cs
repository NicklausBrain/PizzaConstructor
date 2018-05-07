using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Data.Infrastucture;

namespace PizzaConstructor.Core
{
    public class DataCreator<T, K> where T : class
    {
        private IRepository<T, K> _repository;
        public DataCreator(BaseRepository<T, K> newRepository)
        {
            this._repository = newRepository;
        }

        public void Create(T newItem)
        {
            this._repository.Add(newItem);
            this._repository.SaveChanges();
        }
    }
}
