using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.ImageFileData;
using sariyerpedo.BUSSINES.Extensions;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface IImageService : ICrudService<ImageFile, ImageFileDto>
    {
        Task Process(ImageInputModel image);
        Task<byte[]> GetThumbnail(string no);
        Task<byte[]> GetFullScreen(string no);
        ImageFileDto GetImage(int SliderId);
    }
}
