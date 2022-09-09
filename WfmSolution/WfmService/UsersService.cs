using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WfmCore.Abstraction;
using WfmCore.ViewModel;
using WfmDataContext;
using WfmDomainModel.Models;

namespace WfmService
{
    public class UsersService : IUsersService
    {
        private readonly WfmDbContext _wfmDbContext;
        public UsersService(WfmDbContext wfmDbContext)
        {
            _wfmDbContext = wfmDbContext;
        }

        public async Task<List<UsersDto>> ReadUserData()
        {
            var result = _wfmDbContext.Users.Select(x => new UsersDto
            {
                UserName = x.UserName,
                Password = x.Password,
                Name = x.Name,
                Role = x.Role,
                Email = x.Email,
            }).ToList();
            return result;
        }

        public async Task InsertUserData(UsersDto usersDto)
        {

            users userData = new users()
            {
                UserName = usersDto.UserName,
                Email = usersDto.Email,
                Role = usersDto.Role,
                Name = usersDto.Name,
                Password = usersDto.Password,
            };
            await _wfmDbContext.AddAsync(userData);
            _wfmDbContext.SaveChanges();
        }
    }
}
