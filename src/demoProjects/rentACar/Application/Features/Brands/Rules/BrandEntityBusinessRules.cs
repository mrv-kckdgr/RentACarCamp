using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandEntityBusinessRules
    {
        private readonly IBrandEntityRepository _brandEntityRepository;

        public BrandEntityBusinessRules(IBrandEntityRepository brandEntityRepository)
        {
            _brandEntityRepository = brandEntityRepository;
        }
        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<BrandEntity> result = await _brandEntityRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("BrandEntity name exists.");
        }

        public void BrandShouldExistsWhenRequested(BrandEntity brandEntity)
        {            
            if (brandEntity == null) throw new BusinessException("Requested doest not exist!");
        }
    }
}
