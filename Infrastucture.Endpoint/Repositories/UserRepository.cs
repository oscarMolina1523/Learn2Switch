using Domain.Endpoint.Entities;
using Domain.Endpoint.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;
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

        public async Task<List<User>> GetAll()
        {
            string query = "SELECT * FROM USUARIO;";
            DataTable dataTable =await _dbConexion.ExecuteQueryCommandAsync(query);
            List<User> usuario = dataTable.AsEnumerable()
                .Select(MapEntityFromDataRow)
                .ToList();

            return usuario;
        }

        private User MapEntityFromDataRow(DataRow row)
        {
            return new User()
            {
                Id = _dbConexion.GetDataRowValue<Guid>(row, "ID_USUARIO"),
                UserName = _dbConexion.GetDataRowValue<string>(row, "NOMBRE_USUARIO"),
                UserEmail = _dbConexion.GetDataRowValue<string>(row, "EMAIL"),
                UserPassword = _dbConexion.GetDataRowValue<string>(row, "CONTRASEÑA"),
            };
        }

        public User GetById(Guid id)
        {
            User usuario = null;
            string getQuery = "SELECT * FROM USUARIO WHERE ID_USUARIO = @UsuarioId;";
            SqlCommand sqlCommand = _dbConexion.GetCommand(getQuery);
            SqlParameter parameter = new SqlParameter()
            {
                Direction = ParameterDirection.Input,
                ParameterName = "@UsuarioId",
                SqlDbType = SqlDbType.UniqueIdentifier,
                Value = id
            };
            sqlCommand.Parameters.Add(parameter);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                usuario = new User
                {
                    Id = reader.GetGuid(reader.GetOrdinal("ID_USUARIO")),
                    UserName = reader.GetString(reader.GetOrdinal("NOMBRE_USUARIO")),
                    UserEmail = reader.GetString(reader.GetOrdinal("EMAIL")),
                    UserPassword = reader.GetString(reader.GetOrdinal("CONTRASEÑA")),
                };
            }
            reader.Close();
            return usuario;
        }
    }
}
