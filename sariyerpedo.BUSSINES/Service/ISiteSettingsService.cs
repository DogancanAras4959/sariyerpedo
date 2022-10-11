using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.SiteSettingData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface ISiteSettingsService : ICrudService<SiteSettings, SiteSettingDto>
    {
        SiteSettingDto getSiteSetting(int Id);
    }
}
