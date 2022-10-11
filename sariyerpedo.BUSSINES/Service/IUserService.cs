using sariyerpedo.BUSSINES.CRUD;
using sariyerpedo.BUSSINES.DTOS.UserData;
using sariyerpedo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.Service
{
    public interface IUserService : ICrudService<Users, UserDto>
    {
        bool login(string username, string password);
        UserDto getUserByName(string userName);
    }
}
