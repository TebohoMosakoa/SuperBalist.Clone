using AutoMapper;
using Promotion.GRPC.Models;
using Promotion.GRPC.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promotion.GRPC.Mappings
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<Item, ItemModel>().ReverseMap();
            CreateMap<Promo, PromotionModel>().ReverseMap();
        }
    }
}
