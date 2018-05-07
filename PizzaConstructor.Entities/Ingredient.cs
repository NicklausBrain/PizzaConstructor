using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaConstructor.Entities
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.Pizza = new List<PizzaItem>();
            this.Template = new List<PizzaTemplate>();
        }

        public Ingredient(Guid id, string name, decimal price, string imageUrl,string imageUrlMain, Categories category, int index)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.ImageUrl = imageUrl;
            this.Category = category;
            this.ImageUrlMain = imageUrlMain;
            this.Pizza = new List<PizzaItem>();
            this.Template = new List<PizzaTemplate>();
            this.Index = index;
        }

        [Key]
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
        
        public decimal Price { get; protected set; }
        
        public string ImageUrl { get; protected set; }

        public string ImageUrlMain { get; protected set; }

        public Categories Category { get; protected set; }
        
        public virtual ICollection<PizzaItem> Pizza { get; protected set; }
       
        public virtual ICollection<PizzaTemplate> Template { get; protected set; }

        public int Index { get; protected set; }
    }
}
