using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using sariyerpedo.BUSSINES.DTOS.LanguageData;
using sariyerpedo.BUSSINES.DTOS.TreatmentData;
using sariyerpedo.BUSSINES.Extensions;
using sariyerpedo.BUSSINES.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Areas.admin.Controllers
{
    [Area("admin")]
    public class tedaviController : Controller
    {

        #region Fields

        private readonly ITreatmentService _treatmentService;
        private readonly ILanguageService _languageService;
        private readonly ILangCountryService _langCountryService;
        private readonly IImageTreatmentService _imageService;

        public tedaviController(ITreatmentService treatmentService, ILangCountryService langCountryService, ILanguageService languageService)
        {
            _treatmentService = treatmentService;
            _languageService = languageService;
            _langCountryService = langCountryService;
        }

        #endregion

        #region Tedavi  

        [HttpGet]
        [Authorize]
        public IActionResult tedaviler()
        {
            var treatmentListLanguageTR = _treatmentService.listToTrTreatment();
            var treatmentListLanguageENG = _treatmentService.listToEngTreatment();

            ViewBag.SelectLanguageTR = treatmentListLanguageTR;
            ViewBag.SelectLanguageENG = treatmentListLanguageENG;

            return View(_treatmentService.GetAll());
        }

        [HttpPost]
        public IActionResult tedaviyiesle(int postIds, int selectIds) 
        {
            var treatment = _treatmentService.Get(postIds);
            var selectedTreatment = _treatmentService.Get(selectIds);
            var getLangaugeSyncTreatment = _languageService.getPostLanguage(treatment.title);

            if(getLangaugeSyncTreatment != null)
            {
                if(treatment.languageId == 1)
                {
                    getLangaugeSyncTreatment.langTitleTr = selectedTreatment.title;
                    _languageService.Update(getLangaugeSyncTreatment);
                }
                else if(treatment.languageId == 2)
                {
                    getLangaugeSyncTreatment.langTitleEng = selectedTreatment.title;
                    _languageService.Update(getLangaugeSyncTreatment);
                }

                return Redirect("tedaviler");
            }

            else
            {
                LanguageDto model = new LanguageDto();

                if (treatment.languageId == 1)
                {
                    model.langTitleTr = treatment.title;
                    model.langTitleEng = selectedTreatment.title;
                }
                else if(treatment.languageId == 2)
                {
                    model.langTitleEng = treatment.title;
                    model.langTitleTr = selectedTreatment.title;
                }

                _languageService.Insert(model);
                return Redirect("tedaviler");

            }
        }

        [HttpGet]
        public IActionResult tedaviekle()
        {
            var langList = _langCountryService.GetAll();
            ViewBag.Langs = new SelectList(langList, "Id", "langTitle");
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(100 * 1024 * 1024)]
        public async Task<IActionResult> tedaviekle(TreatmentDto model, IFormFile image)
        {
            if(image != null)
            {
                int Id = _treatmentService.InsertTreatment(model);

                if (Id > 0)
                {
                    await _imageService.Process(new ImageInputModel
                    {
                        Name = image.FileName,
                        Type = image.ContentType,
                        Content = image.OpenReadStream(),
                        SliderId = Id,
                    });

                    return Redirect("tedaviler");
                }
                else
                {
                    return Redirect("tedaviler");
                }
            }

            return View();
        }

        #endregion


    }
}
