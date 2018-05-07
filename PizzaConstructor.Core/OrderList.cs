using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.Core
{
   public  class OrderList
    {
        private IOrderRepository _orderRepository;
      
        public OrderList(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }

        public List<OrderDto> GetOrdersList(int index, int num)
        {

            var orders = this._orderRepository.GetList().OrderByDescending(order => order.Date).Skip(index).Take(num).ToList();
            var ordersListDto = new List<OrderDto>();
            OrderDto orderDto;
            foreach (var order in orders)
            {
                orderDto = DtoBuilder.ToDto(order);
                orderDto.User = DtoBuilder.ToDto(order.User);
                ordersListDto.Add(orderDto);
            }
            return ordersListDto;
           
        }

    }
}
