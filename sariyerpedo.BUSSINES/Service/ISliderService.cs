using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.SliderData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface ISliderService : ICrudService<Sliders, SliderDto>
    {
        int InsertSlider(SliderDto model);
    }
}
