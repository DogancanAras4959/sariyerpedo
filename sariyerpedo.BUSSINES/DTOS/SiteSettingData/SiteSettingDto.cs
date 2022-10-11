using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.DTOS.SiteSettingData
{
    public class SiteSettingDto : BaseEntityDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public string keywords { get; set; }
        public string slogan { get; set; }
        public string logo { get; set; }
        public string footerlogo { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string youtube { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string copyright { get; set; }
        public string siteUrl { get; set; }

    }
}
