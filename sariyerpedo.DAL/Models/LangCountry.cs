using sariyerpedo.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL.Models
{
    [Table("langCountry")]
    public class LangCountry : BaseEntity
    {
        public LangCountry()
        {
            treatmentList = new List<Treatments>();
        }

        public string langTitle { get; set; }
        public ICollection<Treatments> treatmentList { get; set; }
    }
}
