using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfmCore.ViewModel;

namespace WfmCore.Abstraction
{
    public interface IUsersService
    {
        Task<List<UsersDto>> ReadUserData();
        Task InsertUserData(UsersDto usersDto);
    }
}
