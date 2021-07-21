using Discount.Grpc.Protos;
using System.Threading.Tasks;

namespace Basket.Api.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService = discountProtoService;
        }

        public async Task<CouponModel> GetDiscount(string userName)
        {
            var discountRequest = new GetDiscountRequest { UserName = userName };

            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}
