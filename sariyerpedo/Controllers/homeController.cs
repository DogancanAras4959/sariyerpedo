using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sariyerpedo.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Controllers
{
    public class homeController : Controller
    {
        private readonly LocalizationService _localizationService;
        private readonly IMapper _mapper;

        public homeController(LocalizationService localizationService, IMapper mapper)
        {
            _localizationService = localizationService;
            _mapper = mapper;
        }

        [Route("post")]
        public IActionResult post()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("blog");

            if (menuName == "Blog")
            {
                return RedirectToAction("blog", "anasayfa");
            }

            return View();
        }


        [HttpGet("postdetail/{Id}/{title}", Name = "postdetail")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult postdetail()
        {
            return View();
        }

        [Route("treatments")]
        public IActionResult treatments()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("tedaviler");

            if (menuName == "Tedaviler")
            {
                return RedirectToAction("tedaviler", "anasayfa");
            }
            return View();
        }

        [HttpGet("treatmentdetail/{Id}/{title}", Name = "treatmentdetail")]
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult treatmentdetail()
        {
            return View();
        }


        [Route("contactus")]
        public IActionResult contactus()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("iletişim");

            if (menuName == "İletişim")
            {
                return RedirectToAction("iletisim", "anasayfa");
            }
            return View();
        }

        [Route("booknow")]
        public IActionResult booknow()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("randevual");

            if (menuName == "Randevu Al")
            {
                return RedirectToAction("randevual", "anasayfa");
            }
            return View();
        }

        [Route("ourdoctor")]
        public IActionResult ourdoctor()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("doktorumuz");

            if (menuName == "Doktorumuz")
            {
                return RedirectToAction("doktorumuz", "anasayfa");
            }
            return View();
        }

        [Route("ourclinic")]
        public IActionResult ourclinic()
        {
            string menuName = _localizationService.GetLocalizedHtmlString("kliniğimiz");

            if (menuName == "Kliniğimiz")
            {
                return RedirectToAction("klinigimiz", "anasayfa");
            }
            return View();
        }
    }
}
