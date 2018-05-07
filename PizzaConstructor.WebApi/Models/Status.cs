using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaConstructor.WebApi.Models
{
    public enum Status : int
    {
        New = 0,
        Confirmed = 1,
        Cancelled = 2,
        Delivering = 3,
        Completed = 4
    }
}