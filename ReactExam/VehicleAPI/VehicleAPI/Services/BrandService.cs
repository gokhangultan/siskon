using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DataAccessLayer.Entities;
using Vehicle.DataAccessLayer.Repository;
using VehicleAPI.Models;

namespace VehicleAPI.Services
{
    public interface IBrandService
    {
        Task<int> CreateBrand(BrandModel model);
        Task Update(BrandModel model);
        Task Delete(int id);
        Task<List<BrandDetailModel>> ReadAll(BrandFilterModel filter);
        Task<BrandDetailModel> Read(int id);
        Task<List<BrandLovModel>> ReadLov();
    }
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        public async Task<int> CreateBrand(BrandModel model)
        {
            var entity = _mapper.Map<BrandEntity>(model);
            return await _brandRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _brandRepository.Delete(id);
        }

        public async Task<BrandDetailModel> Read(int id)
        {
            var result = await _brandRepository.Read(id);
            return _mapper.Map<BrandDetailModel>(result);
        }

        public async Task<List<BrandDetailModel>> ReadAll(BrandFilterModel filter)
        {
            var result = await _brandRepository.ReadAll(_mapper.Map<BrandFilterEntity>(filter));
            return _mapper.Map<List<BrandDetailModel>>(result);
        }

        public async Task<List<BrandLovModel>> ReadLov()
        {
            var result = await _brandRepository.ReadLov();
            return _mapper.Map<List<BrandLovModel>>(result);
        }

        public async Task Update(BrandModel model)
        {
            await _brandRepository.Update(_mapper.Map<BrandEntity>(model));
        }
    }
}
