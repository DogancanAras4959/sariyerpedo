using AutoMapper;
using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.RoleData;
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
    public class RoleService : CrudService<Roles, RoleDto>, IRoleService
    {
        public RoleService(IRepository<Roles> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
