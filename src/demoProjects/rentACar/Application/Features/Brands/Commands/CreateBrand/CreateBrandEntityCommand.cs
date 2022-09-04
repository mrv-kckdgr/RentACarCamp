using Application.Features.Brands.Dtos.Brand;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandEntityCommand : IRequest<CreatedBrandEntityDto>
    {
        public string Name { get; set; }

        public class CreateBrandEntityCommandHandler : IRequestHandler<CreateBrandEntityCommand, CreatedBrandEntityDto>
        {
            private readonly IBrandEntityRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandEntityBusinessRules _brandEntityBusinessRules;

            public CreateBrandEntityCommandHandler(IBrandEntityRepository brandRepository, IMapper mapper, BrandEntityBusinessRules brandEntityBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandEntityBusinessRules = brandEntityBusinessRules;
            }

            public async Task<CreatedBrandEntityDto> Handle(CreateBrandEntityCommand request, CancellationToken cancellationToken)
            {
                await _brandEntityBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
                
                BrandEntity mappedBrandEntity = _mapper.Map<BrandEntity>(request);
                BrandEntity createdBrandEntity = await _brandRepository.AddAsync(mappedBrandEntity);
                CreatedBrandEntityDto createdBrandEntityDto = _mapper.Map<CreatedBrandEntityDto>(createdBrandEntity);

                return createdBrandEntityDto;
            }
        }
    }
}
