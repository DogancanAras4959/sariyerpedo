using Microsoft.AspNetCore.Mvc;
using sariyerpedo.BUSSINES.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly ISiteSettingsService _siteSettingService;
        public FooterViewComponent(ISiteSettingsService siteSettingsService)
        {
            _siteSettingService = siteSettingsService;
        }

        public IViewComponentResult Invoke()
        {
            var siteSettingVariable = _siteSettingService.getSiteSetting(1);
            return View(siteSettingVariable);
        }
    }
}
