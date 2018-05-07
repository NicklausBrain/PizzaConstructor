using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.Entities
{
    public class PizzaItem
    {
        public PizzaItem()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public PizzaItem(Guid id, string name, decimal totalCost, string imageUrl/*, Order order*/)
        {
            this.Id = id;
            this.Name = name;
            this.TotalCost = totalCost;
            this.ImageUrl = imageUrl;
            //this.Order = order;
            this.Ingredients = new List<Ingredient>();
        }

        [Key]
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public decimal TotalCost { get; protected set; }

        public string ImageUrl { get; protected set; }

        [Required]
        public virtual ICollection<Ingredient> Ingredients { get; set; }

        public virtual Order Order { get; set; }

        public void AddIngredient(Ingredient ingredient)
        {
            // TODO
        }

        public void RemoveIngredient(Ingredient ingredient)
        {
            // TODO
        }
    }
}
