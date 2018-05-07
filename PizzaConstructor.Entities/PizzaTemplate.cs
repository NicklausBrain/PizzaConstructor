using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.Entities
{
    public class PizzaTemplate
    {
        public PizzaTemplate()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public PizzaTemplate(Guid id,string name, string imageUrl, decimal totalCost)
        {
            this.ImageUrl = imageUrl;
            this.TotalCost = totalCost;
            this.Name = name;
            this.Id = id;
            this.Ingredients = new List<Ingredient>();
        }

        [Key]
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public decimal TotalCost { get; protected set; }

        public string ImageUrl { get; protected set; }

        [Required]
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
