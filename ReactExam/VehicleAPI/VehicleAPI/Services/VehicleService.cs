using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.DataAccessLayer.Entities;
using Vehicle.DataAccessLayer.Repository;
using VehicleAPI.Models;

namespace VehicleAPI.Services
{
    public interface IVehicleService
    {
        Task<int> CreateVehicle(VehicleModel model);
        Task Update(VehicleModel model);
        Task Delete(int id);
        Task<List<VehicleDetailModel>> ReadAll(VehicleFilterModel filter);
        Task<VehicleDetailModel> Read(int id);
        Task UpdateVehicle(VehicleModel vehicleModel);
        Task DeleteVehicle(int id);
    }

    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateVehicle(VehicleModel model)
        {
            var entity = _mapper.Map<VehicleEntity>(model);
            return await _vehicleRepository.Create(entity);
        }

        public async Task Delete(int id)
        {
            await _vehicleRepository.Delete(id);
        }

        public async Task DeleteVehicle(int id)
        {
            await _vehicleRepository.Delete(id);
        }

        public async Task<List<VehicleDetailModel>> ReadAll(VehicleFilterModel filter)
        {
            var result = await _vehicleRepository.ReadAll(_mapper.Map<VehicleFilterEntity>(filter));
            return _mapper.Map<List<VehicleDetailModel>>(result);
        }

        public async Task<VehicleDetailModel> Read(int id)
        {
            var result = await _vehicleRepository.Read(id);
            return _mapper.Map<VehicleDetailModel>(result);
        }

        public async Task Update(VehicleModel model)
        {
            var entity = _mapper.Map<VehicleEntity>(model);
            await _vehicleRepository.Update(entity);
        }

        public async Task UpdateVehicle(VehicleModel vehicleModel)
        {
            var entity = _mapper.Map<VehicleEntity>(vehicleModel);
            await _vehicleRepository.Update(entity);
        }
    }
}
