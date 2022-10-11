using sariyerpedo.DAL.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.DAL.Models
{
    [Table("post")]
    public class Post : BaseEntity
    {
        public Post()
        {

        }

        public string metaTitle { get; set; }
        public string metaDescription { get; set; }
        public string title { get; set; }
        public string spot { get; set; }
        public string image { get; set; }
        public string content { get; set; }
        public int sorted { get; set; }
        public string videoslug { get; set; }

        [ForeignKey("lang")]
        public int LangId { get; set; }

        public Language lang { get; set; }
        
    }
}
