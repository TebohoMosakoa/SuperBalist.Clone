using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Api.Data;
using User.Api.Models;

namespace User.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> Add(ApplicationUser entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ApplicationUser> Delete(string id)
        {
            ApplicationUser entity = await Get(id);
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ApplicationUser> Get(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ApplicationUser> Update(ApplicationUser entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
