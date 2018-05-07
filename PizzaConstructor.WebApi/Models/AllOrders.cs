using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;

namespace PizzaConstructor.WebApi.Models
{
    public class AllOrders
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        
    }
}