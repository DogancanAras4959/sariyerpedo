using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.TreatmentData;
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
    public class TreatmentService : CrudService<Treatments, TreatmentDto>, ITreatmentService
    {
        public TreatmentService(IRepository<Treatments> repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public int InsertTreatment(TreatmentDto model)
        {
            try
            {
                var entity = _mapper.Map<TreatmentDto, Treatments>(model);
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

        public List<TreatmentDto> listTakeTreatment(int max)
        {
            var entity = _repository.Where(x => x.IsActive == true).OrderByDescending(x => x.CreatedTime).Take(max).ToList();
            var entityDto = _mapper.Map<List<Treatments>, List<TreatmentDto>>(entity);
            return entityDto;
        }

        public List<TreatmentDto> listToCreatedTime()
        {
            var entity = _repository.Where(x => x.Id > 0).OrderByDescending(x => x.CreatedTime).Include("category").ToList();
            var entityDto = _mapper.Map<List<Treatments>, List<TreatmentDto>>(entity);
            return entityDto;
        }

        public List<TreatmentDto> listToEngTreatment()
        {
            var entity = _repository.Where(x => x.LangId == 1).ToList();
            var entityDto = _mapper.Map<List<Treatments>, List<TreatmentDto>>(entity);
            return entityDto;
        }

        public List<TreatmentDto> listToKeyword(string keyword)
        {
            var entity = _repository.Where(x => x.title!.Contains(keyword) && x.IsActive == true).OrderByDescending(x => x.CreatedTime).ToList();
            var entityDto = _mapper.Map<List<Treatments>, List<TreatmentDto>>(entity);
            return entityDto;
        }

        public List<TreatmentDto> listToTrTreatment()
        {
            var entity = _repository.Where(x => x.LangId == 2).ToList();
            var entityDto = _mapper.Map<List<Treatments>, List<TreatmentDto>>(entity);
            return entityDto;
        }
    }
}
