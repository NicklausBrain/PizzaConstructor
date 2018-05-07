using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Description;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PizzaConstructor.Core;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Entities;
using PizzaConstructor.WebApi.Models;

namespace PizzaConstructor.WebApi.Controllers
{
    using PizzaConstructor.Core.DTO;

    public class AdminPageController : Controller
    {
        private IOrderRepository orderRepository;
       
        public AdminPageController()
        {
            this.orderRepository = DependencyResolver.Current.GetService<IOrderRepository>();
        }

        [AdminAuthorize]
        public ActionResult Index()
        {
            return this.View();
        }
    }
}
