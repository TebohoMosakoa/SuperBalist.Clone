using Promotion.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotion.Api.Repositories
{
    public interface IPromotionRepository
    {
        Task<List<Promo>> GetPromos();
        Task<Promo> GetPromo(int id);
        Task<bool> CreatePromo(Promo promo);
        Task<bool> UpdatePromo(Promo promo);
        Task<bool> DeletePromo(int id);
    }
}
