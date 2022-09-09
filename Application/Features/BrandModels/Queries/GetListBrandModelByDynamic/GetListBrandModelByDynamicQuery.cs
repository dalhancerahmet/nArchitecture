using Application.Features.BrandModels.Models;
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

namespace Application.Features.BrandModels.Queries.GetListBrandModelByDynamic
{
    public class GetListBrandModelByDynamicQuery : IRequest<BrandModelListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }

        public class GetListBrandModelByDynamicQueryHandler : IRequestHandler<GetListBrandModelByDynamicQuery, BrandModelListModel>
        {
            IBrandModelRepository _brandModelRepository;
            IMapper _mapper;

            public GetListBrandModelByDynamicQueryHandler(IBrandModelRepository brandModelRepository, IMapper mapper)
            {
                _brandModelRepository = brandModelRepository;
                _mapper = mapper;
            }

            public async Task<BrandModelListModel> Handle(GetListBrandModelByDynamicQuery request, CancellationToken cancellationToken)
            {
               IPaginate<BrandModel> brandModel=await _brandModelRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: m => m.Include(c => c.Brand), 
                    index: request.PageRequest.Page, 
                    size: request.PageRequest.PageSize);
               BrandModelListModel brandModelListModel= _mapper.Map<BrandModelListModel>(brandModel);
                return brandModelListModel;
            }
        }
    }
}
