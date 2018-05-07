using System.Collections.Generic;
using System.Linq;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.Core
{
    public class PizzaList
    {
        private IPizzaRepository _pizzaRepository;
       
        public PizzaList(IPizzaRepository pr)
        {
            this._pizzaRepository = pr;
        }
        
        public List<PizzaItemDto> GetPizzasList()
        {
            var pizzas = _pizzaRepository.GetList().ToList();

            var pizzasListDto = new List<PizzaItemDto>();
            foreach (var pizzaItem in pizzas)
            {
                pizzasListDto.Add(DtoBuilder.ToDto(pizzaItem));
            }
            return pizzasListDto;
        }

        //Get all users pizza templates for Order History Page by user Name
        public List<PizzaItemDto> GetPizzasListByUserFullName(string name)
        {
            var pizzasListDto = new List<PizzaItemDto>();
            var pizzas = _pizzaRepository.GetList(p => p.Order.User.Name == name).OrderByDescending(p => p.Order.Date).ToList();    
            foreach (var pizzaItem in pizzas)
            {
                pizzasListDto.Add(DtoBuilder.ToDto(pizzaItem));
            }
            return pizzasListDto;
        }
    }
}
