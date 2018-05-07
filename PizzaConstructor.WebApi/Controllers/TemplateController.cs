

using System;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.WebApi.Controllers
{

    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using PizzaConstructor.Data;
    using PizzaConstructor.Data.Repositories;
    using PizzaConstructor.Entities;

    public class TemplateController : ApiController
    {
        public IEnumerable<TemplateDto> GetTemplates()
        {
            PizzaDataContext db = new PizzaDataContext();
            List<PizzaTemplate> templateList;

            using (TemplateRepository or = new TemplateRepository(db))
            {
                templateList = or.GetList().ToList();
            }

            List<TemplateDto> templateDtoList = new List<TemplateDto>();

            foreach (PizzaTemplate pizzaTemplate in templateList)
            {
                templateDtoList.Add(new TemplateDto()
                {
                    Id = pizzaTemplate.Id,
                    ImageUrl = pizzaTemplate.ImageUrl,
                    Name = pizzaTemplate.Name,
                    TotalCost = pizzaTemplate.TotalCost,
                    //Ingredients = new List<Ingredient>()
                });
            }

            return templateDtoList;
        }

        public IEnumerable<TemplateDto> GetTemplateByName(string name)
        {
            PizzaDataContext db = new PizzaDataContext();
            List<PizzaTemplate> templateList;

            using (TemplateRepository or = new TemplateRepository(db))
            {
                templateList = or.GetList().ToList();
            }

            List<TemplateDto> templateDtoList = new List<TemplateDto>();

            foreach (PizzaTemplate pizzaTemplate in templateList)
            {
                templateDtoList.Add(new TemplateDto()
                {
                    Id = pizzaTemplate.Id,
                    ImageUrl = pizzaTemplate.ImageUrl,
                    Name = pizzaTemplate.Name,
                    TotalCost = pizzaTemplate.TotalCost,
                    //Ingredients = new List<Ingredient>()
                });
            }
           
            return templateDtoList.Where(i => i.Name.ToLower().Contains(name.ToLower()));
        }

        public class TemplateDto
        {
            public Guid Id { get; set; }

            public string Name { get; set; }

            public decimal TotalCost { get; set; }

            public string ImageUrl { get; set; }

            //public List<Ingredient> Ingredients { get; set; }
        }
    }
}
