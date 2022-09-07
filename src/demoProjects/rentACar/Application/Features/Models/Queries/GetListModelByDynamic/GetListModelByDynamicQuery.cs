using Application.Features.Models.Models;
using Application.Features.Models.Queries.GetListModel;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListModelByDynamic
{
    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IMapper _mapper;
            private readonly IModelEntityRepository _modelEntityRepository;

            public GetListModelByDynamicQueryHandler(IMapper mapper, IModelEntityRepository modelEntityRepository)
            {
                _mapper = mapper;
                _modelEntityRepository = modelEntityRepository;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {
                // car models
                IPaginate<ModelEntity> models = await _modelEntityRepository.GetListByDynamicAsync(dynamic: request.Dynamic, include:
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
