using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaConstructor.WebApi.Models
{
    /// <summary>
    /// ViewModel represents action for current user
    /// </summary>
    public class AllowedAction
    {
        public AllowedAction()
        {

        }

        public AllowedAction(string title, string actionName, string controllerName)
        {
            this.Title = title;
            this.ActionName = actionName;
            this.ControllerName = controllerName;
        }

        public string Title { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }
    }
}