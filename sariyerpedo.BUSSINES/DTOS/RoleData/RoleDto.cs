using sariyerpedo.BUSSINES.DTOS.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sariyerpedo.BUSSINES.DTOS.RoleData
{
    public class RoleDto : BaseEntityDto
    {
        public string roleName { get; set; }

        public ICollection<UserDto> userRoles { get; set; }
    }
}
