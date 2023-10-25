using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastucture.Endpoint
{
    public interface ISingletonSqlConnection
    {
        void CloseConnection();
        SqlDataAdapter CreateDataApdapter(string query);
        Task<DataTable> ExecuteQueryCommandAsync(string sql);
        SqlCommand GetCommand(string query);
        T GetDataRowValue<T>(DataRow row, string index, T defaultValue = default);
        void OpenConnection();
    }
}
