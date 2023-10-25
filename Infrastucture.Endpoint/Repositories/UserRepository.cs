using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastucture.Endpoint.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISingletonSqlConnection _dbConexion;
        public UserRepository(ISingletonSqlConnection dbConexion)
        {
            _dbConexion = dbConexion;
        }

        public void Create(User user)
        {
            string insertQuery = "INSERT INTO USUARIO (ID_USUARIO,NOMBRE_USUARIO, CONTRASEÑA, EMAIL) VALUES(@ID,@NombreUsuario,@Contraseña,@Email)";
           
            SqlCommand sqlCommand = _dbConexion.GetCommand(insertQuery);
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter() {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Value = user.Id
                },
                new SqlParameter() {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = user.UserEmail
                },
                new SqlParameter() {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@NombreUsuario",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = user.UserName
                },
                new SqlParameter() {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Contraseña",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = user.UserPassword
                }
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlCommand.ExecuteNonQuery();
        }

        public Task<List<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
