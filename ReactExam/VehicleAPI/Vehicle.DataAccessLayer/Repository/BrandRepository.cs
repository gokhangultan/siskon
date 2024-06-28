using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DataAccessLayer.Entities;
using Vehicle.DataAccessLayer.Utils;

namespace Vehicle.DataAccessLayer.Repository
{
    public interface IBrandRepository : IBaseRepository<int, BrandEntity, BrandDetailEntity, BrandFilterEntity, BrandLovEntity>
    {

    }
    public class BrandRepository : IBrandRepository
    {
        private readonly IDataAccess _dataAccess;
        public BrandRepository(IDataAccess dataAccess)
        {
            this._dataAccess = dataAccess;
        }

        public async Task<int> Create(BrandEntity entity)
        {
            var sql = "dbo.DEF_Brand_Create";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("BrandID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            sqlParams.Add("BrandName", entity.BrandName);
            sqlParams.Add("Active", entity.Active);

            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    await con.ExecuteAsync(
                        sql: sql,
                        param: sqlParams,
                        commandType: CommandType.StoredProcedure
                    );
                    var brandId = sqlParams.Get<int>("BrandID");
                    return brandId;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(int id)
        {
            var sql = "dbo.DEF_Brand_Delete";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("BrandID", id);
            
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

        public async Task<BrandDetailEntity> Read(int id)
        {
            var sql = "dbo.DEF_Brand_Read";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("BrandID", id);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<BrandDetailEntity>
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

        public async Task<List<BrandDetailEntity>> ReadAll(BrandFilterEntity filter)
        {
            var sql = "dbo.DEF_Brand_ReadAll";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("BrandID", filter.BrandId);
            sqlParams.Add("BrandName", filter.BrandName);
            sqlParams.Add("Active", filter.Active);
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<BrandDetailEntity>
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

        public async Task<List<BrandLovEntity>> ReadLov()
        {
            var sql = "dbo.DEF_Brand_Lov";
            var sqlParams = new DynamicParameters();
            try
            {
                using (var con = _dataAccess.CreateConnection())
                {
                    var result = await con.QueryAsync<BrandLovEntity>
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

        public async Task Update(BrandEntity entity)
        {
            var sql = "dbo.DEF_Brand_Update";
            var sqlParams = new DynamicParameters();
            sqlParams.Add("BrandID", entity.BrandId);
            sqlParams.Add("BrandName", entity.BrandName);
            sqlParams.Add("Active", entity.Active);

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
