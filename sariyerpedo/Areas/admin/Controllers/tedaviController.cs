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
using System.IO;
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

        public tedaviController(ITreatmentService treatmentService, ILangCountryService langCountryService, ILanguageService languageService, IImageTreatmentService imageService)
        {
            _treatmentService = treatmentService;
            _languageService = languageService;
            _langCountryService = langCountryService;
            _imageService = imageService;

        }

        #endregion

        #region Tedavi  

        [HttpGet]
        [Authorize]
        public IActionResult tedaviler()
        {
            var treatmentListLanguageTR = _treatmentService.listToTrTreatment();
            var treatmentListLanguageENG = _treatmentService.listToEngTreatment();

            ViewBag.SelectLanguageTR = new SelectList(treatmentListLanguageTR,"Id","title");
            ViewBag.SelectLanguageENG = new SelectList(treatmentListLanguageENG, "Id", "title");

            List<TreatmentDto> treatmentList = _treatmentService.GetAll();
            return View(treatmentList.ToList());
        }

        [HttpPost]
        public IActionResult tedaviyiesle(int postIds, int selectIds) 
        {
            var treatment = _treatmentService.Get(postIds);
            var selectedTreatment = _treatmentService.Get(selectIds);
            var getLangaugeSyncTreatment = _languageService.getPostLanguage(treatment.title);

            if(getLangaugeSyncTreatment != null)
            {
                if(treatment.LangId == 1)
                {
                    getLangaugeSyncTreatment.langTitleTr = selectedTreatment.title;
                    _languageService.Update(getLangaugeSyncTreatment);
                }
                else if(treatment.LangId == 2)
                {
                    getLangaugeSyncTreatment.langTitleEng = selectedTreatment.title;
                    _languageService.Update(getLangaugeSyncTreatment);
                }

                return Redirect("tedaviler");
            }

            else
            {
                LanguageDto model = new LanguageDto();

                if (treatment.LangId == 1)
                {
                    model.langTitleTr = treatment.title;
                    model.langTitleEng = selectedTreatment.title;
                }
                else if(treatment.LangId == 2)
                {
                    model.langTitleEng = treatment.title;
                    model.langTitleTr = selectedTreatment.title;
                }

                _languageService.Insert(model);
                return Redirect("tedaviler");

            }
        }

        [HttpGet]
        [Authorize]

        public IActionResult tedaviekle()
        {
            var langList = _langCountryService.GetAll();
            ViewBag.Langs = new SelectList(langList, "Id", "langTitle");
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(100 * 1024 * 1024)]
        public async Task<IActionResult> tedaviolustur(TreatmentDto model, IFormFile image)
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
                        TreatmentId = Id,
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

        [HttpGet]
        [Authorize]
        public IActionResult tedaviduzenle(int Id, string durum = "")
        {
            var treatment = _treatmentService.Get(Id);

            var langList = _langCountryService.GetAll();
            ViewBag.Langs = new SelectList(langList, "Id", "langTitle");

            var newList = _treatmentService.GetAll();
            ViewBag.News = newList;

            var imageFile = _imageService.GetImage(treatment.Id);
            ViewBag.Image = imageFile;

            if (durum == "")
            {
                TempData["durum"] = null;
            }
            else
            {
                TempData["durum"] = durum;
            }

            return View(treatment);
        }

        [HttpPost]
        public async Task<IActionResult> tedaviguncelle(TreatmentDto model, IFormFile image)
        {
            try
            {
                if (image != null)
                {

                    var slider = _treatmentService.Get(model.Id);
                    var imageSlider = _imageService.GetImage(slider.Id);

                    if (imageSlider != null)
                    {
                        var originPath = imageSlider.folder + "Original_" + imageSlider.ImageNo + ".jpg";
                        var thumbnailPath = imageSlider.folder + "Thumbnail_" + imageSlider.ImageNo + ".jpg";
                        var fullscrenPath = imageSlider.folder + "Fullscreen_" + imageSlider.ImageNo + ".jpg";

                        var storageOrigin = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{originPath}".Replace("/", "\\"));
                        var storageThumbnail = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{thumbnailPath}".Replace("/", "\\"));
                        var storageFullscreen = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{fullscrenPath}".Replace("/", "\\"));

                        List<string> storageList = new List<string>
                    {
                        storageOrigin,
                        storageThumbnail,
                        storageFullscreen
                    };

                        foreach (var item in storageList)
                        {
                            FileInfo file = new FileInfo(item);
                            if (file.Exists)
                                file.Delete();
                        }

                        _imageService.Delete(imageSlider.Id);
                    }

                    _treatmentService.Update(model);

                    await _imageService.Process(new ImageInputModel
                    {
                        Name = image.FileName,
                        Type = image.ContentType,
                        Content = image.OpenReadStream(),
                        SliderId = slider.Id,
                    });

                    return Redirect("tedaviler");
                }
                else
                {
                    return Redirect("tedaviler");
                }
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        [HttpGet]
        public IActionResult tedavidurumduzenle(int Id)
        {
            var slider = _treatmentService.Get(Id);

            if (slider.IsActive == true)
            {
                slider.IsActive = false;
            }
            else
            {
                slider.IsActive = true;
            }

            _treatmentService.Update(slider);

            return Redirect("tedaviler");
        }

        [HttpGet]
        public IActionResult tedavisil(int Id)
        {
            var slider = _treatmentService.Get(Id);

            var imageSlider = _imageService.GetImage(slider.Id);

            if (imageSlider != null)
            {
                var originPath = imageSlider.folder + "Original_" + imageSlider.ImageNo + ".jpg";
                var thumbnailPath = imageSlider.folder + "Thumbnail_" + imageSlider.ImageNo + ".jpg";
                var fullscrenPath = imageSlider.folder + "Fullscreen_" + imageSlider.ImageNo + ".jpg";

                var storageOrigin = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{originPath}".Replace("/", "\\"));
                var storageThumbnail = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{thumbnailPath}".Replace("/", "\\"));
                var storageFullscreen = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{fullscrenPath}".Replace("/", "\\"));

                List<string> storageList = new List<string>
                    {
                        storageOrigin,
                        storageThumbnail,
                        storageFullscreen
                    };

                foreach (var item in storageList)
                {
                    FileInfo file = new FileInfo(item);
                    if (file.Exists)
                        file.Delete();
                }

                _imageService.Delete(imageSlider.Id);
            }

            _treatmentService.Delete(slider.Id);

            return Redirect("tedaviler");

        }

        #endregion


    }
}
