using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.LanguageData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface ILanguageService : ICrudService<Language, LanguageDto>
    {
        LanguageDto getPostLanguage(string title); 
    }
}
