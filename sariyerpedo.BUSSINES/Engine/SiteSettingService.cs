using AutoMapper;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.SiteSettingData;
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
    public class SiteSettingService : CrudService<SiteSettings, SiteSettingDto>, ISiteSettingsService
    {
        public SiteSettingService(IRepository<SiteSettings> repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public SiteSettingDto getSiteSetting(int Id)
        {
            var entity = _repository.Where(x => x.Id == Id).OrderByDescending(x => x.CreatedTime).SingleOrDefault();
            var entityDto = _mapper.Map<SiteSettings, SiteSettingDto>(entity);
            return entityDto;
        }
    }
}
