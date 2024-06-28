using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.DataAccessLayer.Entities;
using Vehicle.DataAccessLayer.Utils;

namespace Vehicle.DataAccessLayer.Repository
{
    public interface IVehicleRepository
    {
        Task<int> Create(VehicleEntity entity);
        Task Delete(int id);
        Task<VehicleDetailEntity> Read(int id);
        Task<List<VehicleDetailEntity>> ReadAll(VehicleFilterEntity filter);
        Task Update(VehicleEntity entity);
    }

    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDataAccess _dataAccess;

        public VehicleRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> Create(VehicleEntity entity)
        {
            var sql = "dbo.DEF_Vehicle_Create";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("VehicleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            sqlParams.Add("Name", entity.Name);
            sqlParams.Add("ModelID", entity.ModelId);
            sqlParams.Add("Active", entity.IsActive);

            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    await con.ExecuteAsync(
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );
                    var vehicleId = sqlParams.Get<int>("VehicleID");
                    return vehicleId;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(int id)
        {
            var sql = "dbo.DEF_Vehicle_Delete";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("VehicleID", id);

            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    await con.ExecuteAsync(
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<VehicleDetailEntity> Read(int id)
        {
            var sql = "dbo.DEF_Vehicle_Read";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("VehicleID", id);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<VehicleDetailEntity>
                    (
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.SingleOrDefault();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<List<VehicleDetailEntity>> ReadAll(VehicleFilterEntity filter)
        {
            var sql = "dbo.DEF_Vehicle_ReadAll";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("VehicleID", filter.VehicleId);
            sqlParams.Add("Name", filter.Name);
            sqlParams.Add("ModelID", filter.ModelId);
            sqlParams.Add("Active", filter.IsActive);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<VehicleDetailEntity>
                    (
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );

                    return result.AsList();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Update(VehicleEntity entity)
        {
            var sql = "dbo.DEF_Vehicle_Update";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("VehicleID", entity.VehicleId);
            sqlParams.Add("Name", entity.Name);
            sqlParams.Add("ModelID", entity.ModelId);
            sqlParams.Add("Active", entity.IsActive);

            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    await con.ExecuteAsync(
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
