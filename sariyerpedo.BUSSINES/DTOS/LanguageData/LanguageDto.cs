using sariyerpedo.BUSSINES.DTOS.PostData;
using sariyerpedo.BUSSINES.DTOS.TreatmentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.DTOS.LanguageData
{
    public class LanguageDto : BaseEntityDto
    {
        public string langTitleEng { get; set; }
        public string langTitleTr { get; set; }

    }
}
