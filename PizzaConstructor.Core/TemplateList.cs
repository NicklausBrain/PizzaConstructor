using System.Collections.Generic;
using System.Linq;
using PizzaConstructor.Core.DTO;
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.Core
{
    public class TemplateList
    {
        private ITemplateRepository _templateRepository;
        //private IRepository<PizzaTemplate, Guid> _templateRepository;
        //public TemplateList(BaseRepository<PizzaTemplate, Guid> templateRepository)
        //{
        //    this._templateRepository = templateRepository;
        //}
        public TemplateList(ITemplateRepository templateRepository)
        {
            this._templateRepository = templateRepository;
        }
        //Get all pizza templates for Templates Page
        public List<TemplateDto> GetTemplatesList()
        {
            var tempates = this._templateRepository.GetList().ToList();
            var templatesListDto = new List<TemplateDto>();
            foreach (var template in tempates)
            {
                templatesListDto.Add(DtoBuilder.ToDto(template));
            }
            return templatesListDto;
        }

        //Get pizza templates by name for Templates Page 
        public List<TemplateDto> GetTemplatesListByName(string name)
        {
            var tempates = this._templateRepository.GetList(temp => temp.Name.ToLower().Contains(name.ToLower())).ToList();
            var templatesListDto = new List<TemplateDto>();

            foreach (var template in tempates)
            {
                templatesListDto.Add(DtoBuilder.ToDto(template));
            }

            return templatesListDto;
        }
    }
}
