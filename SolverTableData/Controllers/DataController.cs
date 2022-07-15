using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SolverTableData.Services.Interfaces;

namespace SolverTableData.Controllers
{
    public class DataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITableService _tableService;

        public DataController(IConfiguration configuration, ITableService tableService)
        {
            _configuration = configuration;
            _tableService = tableService;
        }
        
        /// <summary>
        /// Get table data
        /// </summary>
        /// <param name="databaseId">Id of the db to get the connection string</param>
        /// <param name="tableName">Table to retrieve data from</param>
        /// <param name="column">Column to filter on if desired</param>
        /// <param name="value">If include column include what you want to match</param>
        /// <returns>json data from table</returns>
        [HttpGet("{databaseId}/data/{tableName}")]
        public IActionResult GetTableData([FromRoute] string databaseId, [FromRoute] string tableName, [FromQuery] string column = null, [FromQuery] string value = null)
        {
            string connectionString = _configuration.GetConnectionString(databaseId);
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                return BadRequest("databaseId is not a valid database identifier");
            }
            
            try
            {
                if (!string.IsNullOrWhiteSpace(column))
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        return Ok(_tableService.GetTableDataRowsByValue(databaseId, tableName, column, value));
                    }

                    // if we have column defined, value is required
                    return BadRequest("Value must be supplied if Column is defined");
                }

                return Ok(_tableService.GetTableData(databaseId, tableName));
            }
            catch (Exception ex)
            {
                // just a catch all for simplicity
                return UnprocessableEntity(ex.Message);
            }
        }
    }
}
