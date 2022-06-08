using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VaporApp.Application.Requests.Orders;
using VaporApp.Domain.Entities;

namespace VaporApp.Application.Mappings
{
    internal class OrdersMappingProfile : Profile
    {
        public OrdersMappingProfile()
        {
            CreateMap<CreateOrdersRequest, Orders>();
            CreateMap<Orders, CreateOrdersRequest>();

            CreateMap<UpdateOrdersRequest, Orders>();
            CreateMap<Orders, UpdateOrdersRequest>();
        }
    }
}
