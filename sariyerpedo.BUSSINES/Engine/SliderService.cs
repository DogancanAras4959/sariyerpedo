using AutoMapper;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.SliderData;
using sariyerpedo.BUSSINES.Service;
using sariyerpedo.CORE.Repository;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Engine
{
    public class SliderService : CrudService<Sliders,SliderDto>, ISliderService
    {
        public SliderService(IRepository<Sliders> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public int InsertSlider(SliderDto model)
        {
            try
            {
                var entity = _mapper.Map<SliderDto, Sliders>(model);
                _repository.Add(entity);
                _repository.Save();
                model.Id = entity.Id;
                return model.Id;
            }
            catch (Exception ex)
            {
                return 0;
            }
          
        }
    }
}
