using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using sariyerpedo.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Controllers
{
    public class anasayfaController : Controller
    {
        private readonly LocalizationService _localizationService;
        private readonly IMapper _mapper;

        public anasayfaController(LocalizationService localizationService, IMapper mapper)
        {
            _localizationService = localizationService;
            _mapper = mapper;
        }

        public IActionResult sayfa()
        {
            string name = _localizationService.GetLocalizedHtmlString("anasayfa");
            return View();
        }

        [Route("blog")]
        public IActionResult blog()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("blog");

            if (menuName == "Blogs")
            {
                return RedirectToAction("post", "home");
            }
            return View();
        }


        [HttpGet("gonderi/{Id}/{title}", Name = "gonderi")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult gonderi()
        {
            return View();
        }

        [Route("tedaviler")]
        public IActionResult tedaviler()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("tedaviler");

            if (menuName == "Treatments")
            {
                return RedirectToAction("treatments", "home");
            }
            return View();
        }

        [HttpGet("islem/{Id}/{title}", Name = "islem")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult islem()
        {
            return View();
        }


        [Route("iletisim")]
        public IActionResult iletisim()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("iletişim");

            if (menuName == "Contact Us")
            {
                return RedirectToAction("contactus", "home");
            }

            return View();
        }

        [Route("randevual")]
        public IActionResult randevual()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("randevual");

            if (menuName == "Book Now")
            {
                return RedirectToAction("booknow", "home");
            }
            return View();
        }

        [Route("doktorumuz")]
        public IActionResult doktorumuz()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("doktorumuz");

            if (menuName == "Our Doctor")
            {
                return RedirectToAction("ourdoctor", "home");
            }
            return View();
        }

        [Route("klinigimiz")]
        public IActionResult klinigimiz()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("kliniğimiz");

            if (menuName == "Our Clinic")
            {
                return RedirectToAction("ourclinic", "home");
            }
            return View();
        }

        #region Diller

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return LocalRedirect(returnUrl);
        }

        #endregion
    }
}
