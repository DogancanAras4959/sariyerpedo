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
    [Table("treatments")]
    public class Treatments : BaseEntity
    {
        public Treatments()
        {
            imageFileForTreatmentList = new List<ImageFileTreatment>();
        }

        [Required]
        [MaxLength(120)]
        public string title { get; set; }

        [Required]
        [MaxLength(200)]
        public string spot { get; set; }

        [Required]
        public string content { get; set; }

        [Required]
        [MaxLength(160)]
        public string metaTitle { get; set; }

        [Required]
        [MaxLength(200)]
        public string metaDescription { get; set; }

        [Required]
        [MaxLength(75)]
        public string Video { get; set; }

        public int TreatmentId { get; set; }


        [ForeignKey("lang")]
        public int LangId { get; set; }
        public LangCountry lang { get; set; }


        public ICollection<ImageFileTreatment> imageFileForTreatmentList { get; set; }

    }
}
