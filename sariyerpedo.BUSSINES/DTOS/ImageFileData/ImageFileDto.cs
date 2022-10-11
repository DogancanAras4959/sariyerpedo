using sariyerpedo.BUSSINES.DTOS.SliderData;
using sariyerpedo.BUSSINES.DTOS.TreatmentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.DTOS.ImageFileData
{
    public class ImageFileDto : BaseEntityDto
    {
        public string folder { get; set; }
        public string OriginalFileName { get; set; }
        public string OriginalType { get; set; }
        public byte[] OriginalContent { get; set; }
        public byte[] ThumbnailContent { get; set; }
        public byte[] FullscreenContent { get; set; }
        public Guid ImageNo { get; set; }

        public int SliderId { get; set; }
        public SliderDto sliderImage { get; set; }
    }
}
