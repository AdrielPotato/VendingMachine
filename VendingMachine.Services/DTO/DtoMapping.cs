using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using AutoMapper;

namespace VendingMachine.Services.DTO
{
    public class DtoMapping : Profile
    {
        public DtoMapping()
        {
            this.CreateMap<Product, ProductDto>().ReverseMap();
            this.CreateMap<Product, CreateProductDto>().ReverseMap();
            this.CreateMap<Product, UpdateProductDto>().ReverseMap();
            this.CreateMap<Order, OrderDto>().ReverseMap();
            this.CreateMap<Order, CreateOrderDto>().ReverseMap();

        }
    }
}
