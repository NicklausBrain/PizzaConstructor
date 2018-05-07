using System.ComponentModel.DataAnnotations;
using PizzaConstructor.Core.DTO;

namespace PizzaConstructor.WebApi.Models
{
    public class OrderPostModel
    {
        [Required]
        public bool IsTemplate { get; set; }

        [Required]
        public PizzaItemDto Pizza { get; set; }

        [Required]
        public ContactDto Contact { get; set; }
    }
}