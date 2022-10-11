using sariyerpedo.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL.Models
{
    [Table("sliders")]
    public class Sliders : BaseEntity
    {
        public Sliders()
        {
            imageFileForSliderList = new List<ImageFile>();
        }

        public string title { get; set; }
        public string subTitle { get; set; }
        public string slogan { get; set; }
        public string url { get; set; }
        public string UrlTitle { get; set; }
        public int sorted { get; set; }

        public ICollection<ImageFile> imageFileForSliderList { get; set; }
    }
}
