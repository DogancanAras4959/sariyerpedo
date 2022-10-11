﻿using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.RoleData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface IRoleService : ICrudService<Roles, RoleDto>
    {
    }
}
