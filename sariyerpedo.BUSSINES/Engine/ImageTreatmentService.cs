using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.ImageFileTreatmentData;
using sariyerpedo.BUSSINES.Extensions;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.CORE.Repository;
using sariyerpedo.DAL.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Engine
{
    public class ImageTreatmentService : CrudService<ImageFileTreatment, ImageFileTreatmentDto>, IImageTreatmentService
    {
        private const int ThumbnailWdith = 300;
        private const int FullScreenWidth = 1000;

        public ImageTreatmentService(IRepository<ImageFileTreatment> repository, IMapper mapper) : base(repository,mapper)
        {

        }

        public Task<byte[]> GetFullScreen(string no) => _repository.Where(x => x.ImageNo.ToString() == no).Select(x => x.FullscreenContent).FirstOrDefaultAsync();

        public ImageFileTreatmentDto GetImage(int SliderId)
        {
            var entity = _repository.Where(x => x.TreatmentId == SliderId).FirstOrDefault();
            var entityDto = _mapper.Map<ImageFileTreatment, ImageFileTreatmentDto>(entity);
            return entityDto;
        }

        public Task<byte[]> GetThumbnail(string no) => _repository.Where(x => x.ImageNo.ToString() == no).Select(x => x.ThumbnailContent).FirstOrDefaultAsync();

        public async Task Process(ImageInputModel image)
        {
            var imageCount = _repository.Where(x => x.Id > 0).Count();

            try
            {
                using var imageResult = await Image.LoadAsync(image.Content);

                var id = Guid.NewGuid();
                var path = $"/images/{imageCount % 1000}/";
                var name = $"{id}.jpg";

                var storage = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{path}".Replace("/", "\\"));

                if (!Directory.Exists(storage))
                {
                    Directory.CreateDirectory(storage);
                }

                await SaveImage(imageResult, $"Original_{name}", storage, imageResult.Width);
                await SaveImage(imageResult, $"Fullscreen_{name}", storage, FullScreenWidth);
                await SaveImage(imageResult, $"Thumbnail_{name}", storage, ThumbnailWdith);

                ImageFileTreatment newImage = new ImageFileTreatment
                {
                    TreatmentId = image.TreatmentId,
                    folder = path,
                    IsActive = true,
                    OriginalFileName = $"Original_{name}",
                    OriginalType = image.Type,
                    FullscreenContent = id.ToByteArray(),
                    ThumbnailContent = id.ToByteArray(),
                    OriginalContent = id.ToByteArray(),
                    ImageNo = id,
                };

                await _repository.Add(newImage);
                _repository.Save();
            }
            catch (Exception ex)
            {

            }
        }

        private async Task SaveImage(Image image, string name, string path, int resizeWidth)
        {
            var width = image.Width;
            var height = image.Height;

            if (width > resizeWidth)
            {
                height = (int)((double)resizeWidth / width * height);
                width = resizeWidth;
            }

            image.Mutate(i => i.Resize(new Size(width, height)));
            image.Metadata.ExifProfile = null;

            await image.SaveAsJpegAsync($"{path}/{name}", new JpegEncoder
            {
                Quality = 75,
            });

        }
    }
}
