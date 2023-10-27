using Dapper;
using FaceAzureReport.Data;
using FaceAzureReport.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FaceAzureReport.Services
{
    public class ReportBalanceSheetStandardService
    {
        private readonly DbConnection _dbConnection;
        public ReportBalanceSheetStandardService(DbConnection dbConnection) { _dbConnection = dbConnection; }

        public async Task<IEnumerable<BalanceSheetStandard>> GetReportBalanceSheetStandard()
        {
            using (var connection = _dbConnection.GetConnection())
            {
                string sqlStatement = "SELECT * FROM VCSRPBalanceSheetStandard";
                return await connection.QueryAsync<BalanceSheetStandard>(sqlStatement);
            }
        }
    } 
}
