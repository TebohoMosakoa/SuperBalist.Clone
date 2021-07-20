using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Promotion.Api.Data;
using Promotion.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotion.Api.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly PromotionContext _context;
        public PromotionRepository(PromotionContext context)
        {
            _context = context;
        }
        public async Task<bool> CreatePromo(Promo promo)
        {
            try
            {
                await _context.Promotions.AddAsync(promo);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeletePromo(int id)
        {
            try
            {
                var promo = await _context.Promotions.FindAsync(id);
                _context.Promotions.Remove(promo);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Promo> GetPromo(int id)
        {
            return await _context.Promotions.FindAsync(id);
        }

        public async Task<List<Promo>> GetPromos()
        {
            return await _context.Promotions.ToListAsync();
        }

        public async Task<bool> UpdatePromo(Promo promo)
        {
            try
            {
                _context.Entry(promo).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
