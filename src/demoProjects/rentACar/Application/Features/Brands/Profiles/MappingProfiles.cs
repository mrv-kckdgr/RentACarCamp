using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos.Brand;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BrandEntity, CreatedBrandEntityDto>().ReverseMap();
            CreateMap<BrandEntity, CreateBrandEntityCommand>().ReverseMap();
            CreateMap<BrandEntity, BrandListDto>().ReverseMap();
            CreateMap<IPaginate<BrandEntity>, BrandListModel>().ReverseMap();
            CreateMap<BrandEntity, BrandGetByIdDto>().ReverseMap();
        }
    }
}
