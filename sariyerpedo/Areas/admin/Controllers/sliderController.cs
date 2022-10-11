using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using sariyerpedo.BUSSINES.DTOS.SliderData;
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
    public class sliderController : Controller
    {

        #region Fields

        private readonly ISliderService _sliderService;
        private readonly IImageService _imageService;

        public sliderController(ISliderService sliderService, IImageService imageService)
        {
            _sliderService = sliderService;
            _imageService = imageService;
        }

        #endregion

        #region Slider

        [HttpGet]
        [Authorize]
        public IActionResult sliderlar()
        {
            return View(_sliderService.GetAll());
        }

        [HttpGet]
        [Authorize]
        public IActionResult sliderkayit()
        {
            return View();
        }

        [HttpPost]
        [RequestSizeLimit(100 * 1024 * 1024)] //En fazla 100mb kadar dosya yüklenebilir
        public async Task<IActionResult> sliderekle(SliderDto model, IFormFile image)
        {
            if (image != null)
            {

                int Id = _sliderService.InsertSlider(model);

                if (Id > 0)
                {
                    await _imageService.Process(new ImageInputModel
                    {
                        Name = image.FileName,
                        Type = image.ContentType,
                        Content = image.OpenReadStream(),
                        SliderId = Id,
                    });

                    return Redirect("sliderlar");
                }
                else
                {
                    return Redirect("sliderlar");
                }

            }
            else
            {
                return Redirect("sliderlar");
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult sliderduzenle(int Id)
        {
            try
            {
                if (Id > 0)
                {
                    var slider = _sliderService.Get(Id);
                    var imageFile = _imageService.GetImage(slider.Id);
                    ViewBag.Image = imageFile;

                    return View(slider);
                }
                else
                {
                    return Redirect("sliderlar");
                }

            }
            catch (Exception ex)
            {
                return Redirect("sliderlar");
            }

        }

        [HttpPost]
        public async Task<IActionResult> sliderguncelle(SliderDto model, IFormFile image)
        {
            if (image != null)
            {

                var slider = _sliderService.Get(model.Id);
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

                _sliderService.Update(model);

                await _imageService.Process(new ImageInputModel
                {
                    Name = image.FileName,
                    Type = image.ContentType,
                    Content = image.OpenReadStream(),
                    SliderId = slider.Id,
                });

                return Redirect("sliderlar");
            }
            else
            {
                return Redirect("sliderlar");
            }
        }

        [HttpGet]
        public IActionResult sliderdurumduzenle(int Id)
        {
            var slider = _sliderService.Get(Id);
            
            if(slider.IsActive == true)
            {
                slider.IsActive = false;
            }
            else
            {
                slider.IsActive = true;
            }

            _sliderService.Update(slider);

            return Redirect("sliderlar");
        }

        [HttpGet]
        public IActionResult slidersil(int Id)
        {
            var slider = _sliderService.Get(Id);
            _sliderService.Delete(slider.Id);

            return Redirect("sliderlar");

        }

        #endregion

        #region ImageView

        public async Task<IActionResult> Thumbnail(string no)
        {
            var headers = Response.GetTypedHeaders();
            headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromDays(30),
            };

            headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));

            return File(await _imageService.GetThumbnail(no), "image/jpg");
        }

        public async Task<IActionResult> FullScreen(string no)
        {
            var headers = Response.GetTypedHeaders();
            headers.CacheControl = new CacheControlHeaderValue
            {
                Public = true,
                MaxAge = TimeSpan.FromDays(30),
            };

            headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(30));

            return File(await _imageService.GetFullScreen(no), "image/jpg");
        }


        #endregion

    }
}
