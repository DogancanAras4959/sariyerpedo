using AutoMapper;
using sariyerpedo.BUSSINES.DTOS.ImageFileData;
using sariyerpedo.BUSSINES.DTOS.ImageFileTreatmentData;
using sariyerpedo.BUSSINES.DTOS.LangCountryData;
using sariyerpedo.BUSSINES.DTOS.LanguageData;
using sariyerpedo.BUSSINES.DTOS.PostData;
using sariyerpedo.BUSSINES.DTOS.RoleData;
using sariyerpedo.BUSSINES.DTOS.SiteSettingData;
using sariyerpedo.BUSSINES.DTOS.SliderData;
using sariyerpedo.BUSSINES.DTOS.TreatmentData;
using sariyerpedo.BUSSINES.DTOS.UserData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Mapper
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<Roles, RoleDto>();
            CreateMap<RoleDto, Roles>();

            CreateMap<Users, UserDto>().ForMember(x => x.role, y => y.MapFrom(t => t.role));
            CreateMap<UserDto, Users>();

            CreateMap<SiteSettings, SiteSettingDto>();
            CreateMap<SiteSettingDto, SiteSettings>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();

            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();

            CreateMap<LangCountry, LangCountryDto>();
            CreateMap<LangCountryDto, LangCountry>();

            CreateMap<ImageFile, ImageFileDto>();
            CreateMap<ImageFileDto, ImageFile>();

            CreateMap<ImageFileTreatment, ImageFileTreatmentDto>();
            CreateMap<ImageFileTreatmentDto, ImageFileTreatment>();

            CreateMap<Sliders, SliderDto>();
            CreateMap<SliderDto, Sliders>();

            CreateMap<Treatments, TreatmentDto>();
            CreateMap<TreatmentDto, Treatments>();
        }
    }
}
