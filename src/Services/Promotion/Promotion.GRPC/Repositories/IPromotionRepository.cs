using Promotion.GRPC.Models;
using System.Threading.Tasks;

namespace Promotion.GRPC.Repositories
{
    public interface IPromotionRepository
    {
        Promo GetPromo(int id);
    }
}
