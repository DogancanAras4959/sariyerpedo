using Microsoft.AspNetCore.Mvc;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ISiteSettingsService _siteSettingService;
        public HeaderViewComponent(ISiteSettingsService siteSettingsService)
        {
            _siteSettingService = siteSettingsService;
        }

        public IViewComponentResult Invoke()
        {
            var siteSettingVariable = _siteSettingService.getSiteSetting(1);

            MetaViewModel meta = new MetaViewModel()
            {
                Description = siteSettingVariable.description,
                Title = siteSettingVariable.title,
                Image = siteSettingVariable.logo,
                Keywords = siteSettingVariable.keywords,
                ogDescription = siteSettingVariable.description,
                ogImage = siteSettingVariable.logo,
                ogTitle = siteSettingVariable.title,
                Url = siteSettingVariable.siteUrl
            };

            ViewBag.Meta = meta;

            return View(siteSettingVariable);
        }
    }
}
