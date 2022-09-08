using Application.Features.BrandModels.Dtos;
using Application.Features.BrandModels.Models;
using Application.Features.BrandModels.Queries.GetListBrandModel;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BrandModels.Profiles
{
    public class MappingBrandModelProfiles : Profile
    {
        public MappingBrandModelProfiles()
        {
            //ForMember ve Map from ile BrandModel'ın içerisindeki Brand'i mapliyoruz.
            //BrandModel içerisinde bir Brand olduğundan bunu automapper'ın maplemesi için bunu yapıyoruz.
            //Eğer başka maplenecek ilişkili tablolar olursa aynı şekilde yan yana yazacak şekilde devame ediyoruz.
            // Kısacası ilişkisel tablolardaki ilişkiyi ayrıyetten FormMember ile maplememiz gerekiyor.
            CreateMap<BrandModel, BrandModelListDto>()
                .ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name))
                .ReverseMap();

            CreateMap<IPaginate<BrandModel>, BrandModelListModel>().ReverseMap();
        }
    }
}
