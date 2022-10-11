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
    [Table("languages")]
    public class Language : BaseEntity
    {
        public Language()
        {

        }

        [Required]
        [MaxLength(150)]
        public string langTitleEng { get; set; }

        [Required]
        [MaxLength(150)]
        public string langTitleTr { get; set; }

    }
}
