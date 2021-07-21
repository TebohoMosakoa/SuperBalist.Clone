﻿using AutoMapper;
using Basket.Api.Models;
using EventBus.Messages.Events;

namespace Basket.Api.Mappings
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
