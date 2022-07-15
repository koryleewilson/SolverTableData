using System.Data;

namespace SolverTableData.Repositories.Interfaces
{
    public interface ITableRepository
    {
        /// <summary>
        /// Get all the data from the defined table
        /// </summary>
        /// <param name="databaseId">Database ID to get the connection string</param>
        /// <param name="tableName">Table to return the data for</param>
        /// <returns>All the data from the table asked for</returns>
        DataSet GetTableData(string databaseId, string tableName);

        /// <summary>
        /// the data from the table matching requested column and value
        /// </summary>
        /// <param name="databaseId">Database ID to get the connection string</param>
        /// <param name="tableName">Table to return the data for</param>
        /// <param name="column">table column</param>
        /// <param name="value">value of column data to match on</param>
        /// <returns>Matching data from table</returns>
        DataSet GetTableDataRowsByValue(string databaseId, string tableName, string column, string value);
    }
}
