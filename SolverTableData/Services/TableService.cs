using System.Data;
using Newtonsoft.Json;
using SolverTableData.Repositories.Interfaces;
using SolverTableData.Services.Interfaces;

namespace SolverTableData.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepository;

        public TableService(ITableRepository tableRepository)
        {
            _tableRepository = tableRepository;
        }

        public string GetTableData(string databaseId, string tableName)
        {
            // call repository
            DataSet tableData = _tableRepository.GetTableData(databaseId, tableName);

            // convert to json
            return JsonConvert.SerializeObject(tableData, Formatting.Indented);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseId"></param>
        /// <param name="tableName"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string GetTableDataRowsByValue(string databaseId, string tableName, string column, string value)
        {
            // call repository
            DataSet tableData = _tableRepository.GetTableDataRowsByValue(databaseId, tableName, column, value);

            // convert to json and return
            return JsonConvert.SerializeObject(tableData, Formatting.Indented);
        }
    }
}
