using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SolverTableData.Repositories.Interfaces;

namespace SolverTableData.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly IConfiguration _configuration;
        
        public TableRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataSet GetTableData(string databaseId, string tableName)
        {
            // get connection via databaseId
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(databaseId));

            // raw sql - parameterized
            string sql = @$"Select * from {tableName}";

            // create our command
            SqlCommand cmd = new SqlCommand(sql, connection);

            // create an adapter
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // create out dataSet
            DataSet dataSet = new DataSet();
            
            // fill the dataSet with data
            adapter.Fill(dataSet);

            // return our dataSet
            return dataSet;
        }

        public DataSet GetTableDataRowsByValue(string databaseId, string tableName, string column, string value)
        {
            // get connection via databaseId
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString(databaseId));

            // raw sql - parameterized
            string sql = @$"Select * from {tableName} where {column} = @Value";

            // create our command
            SqlCommand cmd = new SqlCommand(sql, connection);

            // avoid sql injection
            cmd.Parameters.Add(new SqlParameter("@Value", value));

            // create an adapter
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // create a dataSet
            DataSet dataSet = new DataSet();
            
            // fill the dataSet
            adapter.Fill(dataSet);

            // return the dataSet
            return dataSet;
        }
    }
}
