using sariyerpedo.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL.Models
{
    [Table("siteSettings")]
    public class SiteSettings : BaseEntity
    {

        [Required]
        [MaxLength(160)]
        public string title { get; set; }

        [Required]
        [MaxLength(300)]
        public string description { get; set; }

        [Required]
        [MaxLength(300)]
        public string keywords { get; set; }

        [Required]
        [MaxLength(120)]
        public string slogan { get; set; }

        [Required]
        [MaxLength(30)]
        public string logo { get; set; }

        [Required]
        [MaxLength(30)]
        public string footerlogo { get; set; }

        [MaxLength(100)]
        public string facebook { get; set; }

        [MaxLength(100)]
        public string instagram { get; set; }

        [MaxLength(100)]
        public string youtube { get; set; }

        [MaxLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string phoneNumber { get; set; }

        [MaxLength(70)]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [MaxLength(300)]
        public string address { get; set; }

        [MaxLength(100)]
        [Required]
        public string copyright { get; set; }

        [Required]
        [MaxLength(70)]
        public string siteUrl { get; set; }
    }
}
