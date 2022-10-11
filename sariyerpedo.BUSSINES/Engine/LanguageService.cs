using AutoMapper;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.LanguageData;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.CORE.Repository;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Engine
{
    public class LanguageService : CrudService<Language, LanguageDto>, ILanguageService
    {
        public LanguageService(IRepository<Language> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public LanguageDto getPostLanguage(string title)
        {
            var entity = _repository.Where(x => x.langTitleTr == title || x.langTitleEng == title).SingleOrDefault();
            var entityDto = _mapper.Map<Language, LanguageDto>(entity);

            if(entityDto != null)
            {
                return new LanguageDto
                {
                    langTitleEng = entityDto.langTitleEng,
                    langTitleTr = entityDto.langTitleTr
                };
            }
            else
            {
                return null;
            }
        }
    }
}
