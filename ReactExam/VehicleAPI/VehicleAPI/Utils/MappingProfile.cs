using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DataAccessLayer.Entities;
using VehicleAPI.Models;

namespace VehicleAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Brand Mapper Configuration
            CreateMap<BrandModel, BrandEntity>();
            CreateMap<BrandFilterModel, BrandFilterEntity>();

            CreateMap<BrandEntity, BrandModel>();
            CreateMap<BrandDetailEntity, BrandDetailModel>();
            CreateMap<BrandLovEntity, BrandLovModel>();


            // Vehicle Mapper Configuration
            CreateMap<VehicleModel, VehicleEntity>();
            CreateMap<VehicleFilterModel, VehicleFilterEntity>();
            CreateMap<VehicleEntity, VehicleModel>();
            CreateMap<VehicleDetailEntity, VehicleDetailModel>();
        }
    }
}
