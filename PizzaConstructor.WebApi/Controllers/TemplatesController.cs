using System.Web.Mvc;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.WebApi.Controllers
{
	using System.Web.Http.Description;
    using System.Collections.Generic;
    using System.Web.Http;
    using PizzaConstructor.Core;
    using PizzaConstructor.Core.DTO;

	public class TemplatesController : ApiController
    {
        private ITemplateRepository _repository;
        
        public TemplatesController()
        {
            this._repository = DependencyResolver.Current.GetService<ITemplateRepository>();
        }

        //GET: api/templates
        [ResponseType(typeof(IEnumerable<TemplateDto>))]
        public IHttpActionResult Get(string name = null)
        {
            var templates = new TemplateList(this._repository);
            List<TemplateDto> templatesList;
            if (templates == null)
            {
                return NotFound();
            }
            if (name != null)
            {
                templatesList = templates.GetTemplatesListByName(name);
            }
            else
            {
                templatesList = templates.GetTemplatesList();
            }
            return Ok<IEnumerable<TemplateDto>>(templatesList);
        }

        protected override void Dispose(bool disposing)
        {
            this._repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
