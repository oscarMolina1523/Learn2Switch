using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastucture.Endpoint
{
    public class SingletonSqlConnection:ISingletonSqlConnection
    {
        private static SingletonSqlConnection _instance;
        private readonly SqlConnection sqlConnection;

        private SingletonSqlConnection()
        {
            string connectionString = "Data Source = DESKTOP-IEJSA1F; Initial Catalog = Prueba1; Persist Security Info = False; Integrated Security = true;TrustServerCertificate=True";
            sqlConnection = new SqlConnection(connectionString);

            OpenConnection();
        }

        public static SingletonSqlConnection GetInstance()
        {
            if (_instance is null)
            {
                _instance = new SingletonSqlConnection();
            }

            return _instance;
        }

        public SqlDataAdapter CreateDataApdapter(string query)
        {
            return new SqlDataAdapter(query, sqlConnection);
        }

        public async Task<DataTable> ExecuteQueryCommandAsync(string sql)
        {
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            command.Dispose();

            return dataTable;
        }

        public SqlCommand GetCommand(string query)
        {
            return new SqlCommand(query, sqlConnection);
        }

        public T GetDataRowValue<T>(DataRow row, string column, T defaultValue = default)
        {
            return !row.IsNull(column) ? row.Field<T>(column) : defaultValue;
        }

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Open) return;

            sqlConnection.Open();
        }


        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed) return;

            sqlConnection.Close();
        }
    }
}

