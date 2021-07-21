using Promotion.GRPC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Promotion.GRPC.Repositories
{
    public interface IPromotionRepository
    {
        Task<List<Promo>> GetPromos(bool isActive);
        Task<Promo> GetPromo(int id);
        Task<bool> CreatePromo(Promo promo);
        Task<bool> UpdatePromo(Promo promo);
        Task<bool> DeletePromo(int id);
    }
}
