using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Web.Common;
using PizzaConstructor.Data;
using PizzaConstructor.Data.Interfaces;
using PizzaConstructor.Data.Repositories;

namespace PizzaConstructor.WebApi
{
    public class NinjectDependencyResolver: IDependencyResolver

    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private PizzaDataContext context = null;

        private PizzaDataContext Context
        {
            get
            {
                if (this.context == null)
                {
                    this.context = new PizzaDataContext();
                }
                return this.context;
            }
        }
        private void AddBindings()
        {
            kernel.Bind<IContactRepository>().To<ContactRepository>()
                .WithConstructorArgument("context", this.Context);
            kernel.Bind<IIngredientRepository>().To<IngredientRepository>()
                .WithConstructorArgument("context", this.Context);
            kernel.Bind<IOrderRepository>().To<OrderRepository>()
                .WithConstructorArgument("context", this.Context);
            kernel.Bind<IPizzaRepository>().To<PizzaRepository>()
                .WithConstructorArgument("context", this.Context);
            kernel.Bind<ITemplateRepository>().To<TemplateRepository>()
                .WithConstructorArgument("context", this.Context);
            kernel.Bind<IUserRepository>().To<UserRepository>()
                .WithConstructorArgument("context", this.Context);
            kernel.Bind<PizzaDataContext>().To<PizzaDataContext>().InRequestScope();
        }
    }

}