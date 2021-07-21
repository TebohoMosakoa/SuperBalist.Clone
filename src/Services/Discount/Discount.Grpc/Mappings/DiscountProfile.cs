using AutoMapper;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;

namespace Discount.Grpc.Mappings
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
