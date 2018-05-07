using System;
using PizzaConstructor.Data.Infrastucture;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.Data.Repositories
{
    public class TemplateRepository : BaseRepository<PizzaTemplate, Guid>, ITemplateRepository
    {
        public TemplateRepository(PizzaDataContext db) 
            : base(db)
        {
        }
    }
}
