using System;
using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Repositories
{
    public class ContactRepository : BaseRepository<Contact, Guid>, IContactRepository
    {
         public ContactRepository(PizzaDataContext db) 
            : base(db)
        {
        }
    }
}
