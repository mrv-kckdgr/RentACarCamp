using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ModelEntity, ModelListDto>().ForMember(x => x.BrandName, opt => opt.MapFrom(x => x.Brand.Name)).ReverseMap();

            CreateMap<IPaginate<ModelEntity>, ModelListModel>().ReverseMap();
        }
    }
}
