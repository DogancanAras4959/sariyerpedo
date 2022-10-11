using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.DTOS.SliderData
{
    public class SliderDto : BaseEntityDto
    {
        public string title { get; set; }
        public string subTitle { get; set; }
        public string slogan { get; set; }
        public string url { get; set; }
        public string UrlTitle { get; set; }
        public int sorted { get; set; }
    }
}
