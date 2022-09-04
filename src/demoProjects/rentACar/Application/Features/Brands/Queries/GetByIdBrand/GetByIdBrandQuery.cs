using Application.Features.Brands.Dtos.Brand;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetListBrand;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<BrandGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdBrandQueryHandler : IRequestHandler<GetByIdBrandQuery, BrandGetByIdDto>
        {
            private readonly IBrandEntityRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandEntityBusinessRules _brandEntityBusinessRules;

            public GetByIdBrandQueryHandler(IBrandEntityRepository brandRepository, IMapper mapper, BrandEntityBusinessRules brandEntityBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandEntityBusinessRules = brandEntityBusinessRules;
            }

            public async Task<BrandGetByIdDto> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                BrandEntity? brandEntity = await _brandRepository.GetAsync(x => x.Id == request.Id);

                _brandEntityBusinessRules.BrandShouldExistsWhenRequested(brandEntity);

                BrandGetByIdDto brandGetByIdDto = _mapper.Map<BrandGetByIdDto>(brandEntity);
                return brandGetByIdDto;
            }
        }
    }
}
