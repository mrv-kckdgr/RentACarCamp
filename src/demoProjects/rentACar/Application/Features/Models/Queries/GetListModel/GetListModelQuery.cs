using Application.Features.Brands.Queries.GetListBrand;
using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelEntityRepository _modelEntityRepository;

            public GetListModelQueryHandler(IMapper mapper, IModelEntityRepository modelEntityRepository)
            {
                _mapper = mapper;
                _modelEntityRepository = modelEntityRepository;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                                       // car models
                IPaginate<ModelEntity> models = await _modelEntityRepository.GetListAsync(include:
                                                    x => x.Include(y => y.Brand),
                                                    index: request.PageRequest.Page,
                                                    size: request.PageRequest.PageSize
                                                    );

                                        // dataModel
                ModelListModel mappedModelS = _mapper.Map<ModelListModel>(models);
                return mappedModelS;
            }
        }
    }
}
