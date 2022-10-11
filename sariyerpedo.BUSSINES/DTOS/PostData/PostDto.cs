using sariyerpedo.BUSSINES.DTOS.LanguageData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.DTOS.PostData
{
    public class PostDto : BaseEntityDto
    {
        public string metaTitle { get; set; }
        public string metaDescription { get; set; }
        public string title { get; set; }
        public string spot { get; set; }
        public string image { get; set; }
        public string content { get; set; }
        public int sorted { get; set; }
        public string videoslug { get; set; }
        public int categoryId { get; set; }
        public int langId { get; set; }
      
        public LanguageDto language { get; set; }

        public string GenerateSlug()
        {
            string phrase = string.Format("{0}", title);

            string str = RemoveAccent(phrase).ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private string RemoveAccent(string text)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(text);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }

    }
}
