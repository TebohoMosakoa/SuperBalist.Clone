using Promotion.GRPC.Protos;
using System.Threading.Tasks;

namespace Basket.Api.GrpcServices
{
    public class PromotionGrpcService
    {
        private readonly PromotionProtoService.PromotionProtoServiceClient _promotionProtoService;

        public PromotionGrpcService(PromotionProtoService.PromotionProtoServiceClient promotionProtoService)
        {
            _promotionProtoService = promotionProtoService;
        }

        public async Task<PromotionModel> GetPromotion(int productId)
        {
            var promotionRequest = new GetProductPromotionRequest { ProductId = productId };

            return await _promotionProtoService.GetProductPromotionAsync(promotionRequest);
        }
    }
}
