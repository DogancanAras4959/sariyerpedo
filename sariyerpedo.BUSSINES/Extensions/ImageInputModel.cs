using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Extensions
{
    public class ImageInputModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Stream Content { get; set; }
        public int TreatmentId { get; set; }
        public int SliderId { get; set; }
    }
}
