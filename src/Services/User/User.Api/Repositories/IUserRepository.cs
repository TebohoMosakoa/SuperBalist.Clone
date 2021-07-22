using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Models;

namespace User.Api.Repositories
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAll();
        Task<ApplicationUser> Get(string id);
        Task<ApplicationUser> Add(ApplicationUser entity);
        Task<ApplicationUser> Update(ApplicationUser entity);
        Task<ApplicationUser> Delete(string id);
    }
}
