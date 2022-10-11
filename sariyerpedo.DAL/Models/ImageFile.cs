using sariyerpedo.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL.Models
{
    [Table("imageFile")]
    public class ImageFile : BaseEntity
    {
        public string folder { get; set; }
        public string OriginalFileName { get; set; }
        public string OriginalType { get; set; }
        public byte[] OriginalContent { get; set; }
        public byte[] ThumbnailContent { get; set; }
        public byte[] FullscreenContent { get; set; }
        public Guid ImageNo { get; set; }
     
        [ForeignKey("slierImage")]
        public int SliderId { get; set; }

        public Sliders sliderImage { get; set; }
    }
}
