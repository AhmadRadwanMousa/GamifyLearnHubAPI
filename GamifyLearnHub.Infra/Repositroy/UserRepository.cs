using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;
        public UserRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateUser(UserDetails userDetails)
        {
            var p = new DynamicParameters();
            p.Add("First_name", userDetails.Firsname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_name", userDetails.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Total_Points", userDetails.Totalpoints, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Date_Of_Birth", userDetails.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("User_Image", userDetails.Userimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_name", userDetails.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Pass", userDetails.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Rold_id", userDetails.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Is_Online", userDetails.Isonline, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Is_Accepted", userDetails.Isaccepted, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("last_login", userDetails.Lastlogin, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("Days_Count", userDetails.Dayscount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("created_userLogin_id", dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("LoginAndRegister_Package.Register", p, commandType: CommandType.StoredProcedure);

            int id = p.Get<int>("created_userLogin_id");
            return id;

        }

        public async Task<int> DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("deleted_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("rows_affected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("User_Package.DeleteUser", p, commandType: CommandType.StoredProcedure);
            int effected_rows = p.Get<int>("rows_affected");
            int deleted_row = p.Get<int>("deleted_id");
            return deleted_row;

        }


        public async Task<List<User>> GetAllUsers()
        {
            var result = await _dbContext.Connection.QueryAsync<User,Userlogin,User>(
            "User_Package.GetAllUsers",
            (user, userLogin) =>
            {
                if (user.Userlogins == null)
                {
                    user.Userlogins = new List<Userlogin>(); 
                }
                user.Userlogins.Add(userLogin);
                return user;
            },
            splitOn: "userId", 
            commandType: CommandType.StoredProcedure
        );
            return result.ToList();
        }

        public async Task<User> GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<User>("User_Package.GetUserById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateUser(UserDetails userDetails)
        {
            var p = new DynamicParameters();
            p.Add("User_id", userDetails.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("First_name", userDetails.Firsname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_name", userDetails.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Total_Points", userDetails.Totalpoints, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Date_Of_Birth", userDetails.Dateofbirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("User_Image", userDetails.Userimage, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_name", userDetails.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Pass", userDetails.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Rold_id", userDetails.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Is_Accepted", userDetails.Isaccepted, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            //p.Add("Is_Online", userDetails.Isonline, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //p.Add("last_login", userDetails.Lastlogin, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            //p.Add("Days_Count", userDetails.Dayscount, dbType: DbType.Int32, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("User_Package.UpdateUser", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }
        public async Task<int> EditUserProfile(UserDetails userDetails)
        {
            var p = new DynamicParameters();
            p.Add("User_id", userDetails.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("First_name", userDetails.Firsname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_name", userDetails.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Date_Of_Birth", userDetails.Dateofbirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("User_Image", userDetails.Userid, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("User_name", userDetails.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Pass", userDetails.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("rows_effected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("User_Package.EditProfile", p, commandType: CommandType.StoredProcedure);
            return p.Get<int>("rows_effected");
        }



    }
}
