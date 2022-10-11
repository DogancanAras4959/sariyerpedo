using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.ImageFileTreatmentData;
using sariyerpedo.BUSSINES.Extensions;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface IImageTreatmentService : ICrudService<ImageFileTreatment, ImageFileTreatmentDto>
    {
        Task Process(ImageInputModel image);
        Task<byte[]> GetThumbnail(string no);
        Task<byte[]> GetFullScreen(string no);
        ImageFileTreatmentDto GetImage(int SliderId);
    }
}
