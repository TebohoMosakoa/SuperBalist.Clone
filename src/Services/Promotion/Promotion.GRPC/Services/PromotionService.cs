using AutoMapper;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Promotion.GRPC.Data;
using Promotion.GRPC.Models;
using Promotion.GRPC.Protos;
using Promotion.GRPC.Repositories;
using System;
using System.Threading.Tasks;

namespace Promotion.GRPC.Services
{
    public class PromotionService : PromotionProtoService.PromotionProtoServiceBase
    {
        private readonly IPromotionRepository _repository;
        private readonly IMapper _mapper;

        public PromotionService(IPromotionRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async override Task<PromotionModel> GetProductPromotion(GetProductPromotionRequest request, ServerCallContext context)
        {
            var promo = _repository.GetPromo(request.ProductId);

            var promoModel = _mapper.Map<PromotionModel>(promo);
            return promoModel;
        }
    }
}
