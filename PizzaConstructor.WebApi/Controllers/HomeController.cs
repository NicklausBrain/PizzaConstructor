
namespace PizzaConstructor.WebApi.Controllers
{    
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        [AllowAnonymous]
        public ActionResult Index(ManageMessageId? message,bool? isDanger)
        {
            ViewBag.Title = "Home Page";
            ViewBag.StatusMessage =
            message == ManageMessageId.LoginError ? "You don`t have permission to attend this page!" :
            message == ManageMessageId.OrderSuccess ? "Your order was added!" :
            "";
            ViewBag.Status = isDanger == true ? "danger" : "success";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Templates()
        {
            return this.View();
        }

        [Authorize]
        public ActionResult PizzaConstructor()
        {
            return this.View();
        }
        [Authorize]
        public ActionResult OrdersHistory()
        {
            return this.View();
        }
    }


    public enum ManageMessageId
    {
        LoginError,
        OrderSuccess
    }
}
