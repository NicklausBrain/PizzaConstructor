using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Repositories
{
    public class UserRepository : BaseRepository<User, string>, IUserRepository
    {
        public UserRepository(PizzaDataContext db) 
            : base(db)
        {
        }
    }
}
