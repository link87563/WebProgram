using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgramApi.Model;
using WebProgramApi.Interface;
using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace WebProgramApi.Service
{
    public class UserService : IUserService
    {
        IConfiguration _configuration;

        public UserService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        IResult IUserService.GetUser(string id)
        {
            var result = new Result();
            DefaultTypeMap.MatchNamesWithUnderscores = true;

            try
            { 
                using (var conn = new OracleConnection(_configuration.GetConnectionString("DefaultConnection"))) 
                {
                    conn.Open();

                    var model = conn.Query<User>(@"select * from yy010 where yy010_user_id = :USER_ID", new { USER_ID = id }).FirstOrDefault();
                    
                    //如果不想要用User Class可以改成object
                    //var model = conn.Query<object>(@"select * from yy010 where yy010_user_id = :USER_ID", new { USER_ID = id }).FirstOrDefault();

                    result.Data = model;
                }

                result.Success();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
