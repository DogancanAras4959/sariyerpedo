using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.TreatmentData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface ITreatmentService : ICrudService<Treatments, TreatmentDto>
    {
        List<TreatmentDto> listToKeyword(string keyword);
        List<TreatmentDto> listToCreatedTime();
        List<TreatmentDto> listTakeTreatment(int max);
        List<TreatmentDto> listToEngTreatment();
        List<TreatmentDto> listToTrTreatment();

        int InsertTreatment(TreatmentDto model);
    }
}
