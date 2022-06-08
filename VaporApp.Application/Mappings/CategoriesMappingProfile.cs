using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VaporApp.Application.Requests.Categories;
using VaporApp.Domain.Entities;

namespace VaporApp.Application.Mappings
{
    internal class CategoriesMappingProfile : Profile
    {
        public CategoriesMappingProfile()
        {
            CreateMap<CreateCategoriesRequest, Categories>();
            CreateMap<Categories, CreateCategoriesRequest>();

            CreateMap<UpdateCategoriesRequest, Categories>();
            CreateMap<Categories, UpdateCategoriesRequest>();
        }
    }
}
