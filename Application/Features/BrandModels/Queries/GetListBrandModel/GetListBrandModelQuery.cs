using Application.Features.BrandModels.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BrandModels.Queries.GetListBrandModel
{

    public class GetListBrandModelQuery : IRequest<BrandModelListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListBrandModelQueryHandler : IRequestHandler<GetListBrandModelQuery, BrandModelListModel>
        {
            IBrandModelRepository _branModelRepository;
            IMapper _mapper;

            public GetListBrandModelQueryHandler(IBrandModelRepository branModelRepository, IMapper mapper)
            {
                _branModelRepository = branModelRepository;
                _mapper = mapper;
            }

            public async Task<BrandModelListModel> Handle(GetListBrandModelQuery request, CancellationToken cancellationToken)
            {
                //Burası önemli 
               IPaginate<BrandModel> models= await _branModelRepository.GetListAsync(include:m=>m.Include(c=>c.Brand),
                    index:request.PageRequest.Page,size:request.PageRequest.PageSize);

               BrandModelListModel mappedBrandModelListModel= _mapper.Map<BrandModelListModel>(models);
                
                return mappedBrandModelListModel;
            }
        }
    }
}
