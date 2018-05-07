using System;
using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Repositories
{
	public class PizzaRepository : BaseRepository<PizzaItem, Guid>, IPizzaRepository
    {
        public PizzaRepository(PizzaDataContext db) 
            : base(db)
        {
        }
    }
}
