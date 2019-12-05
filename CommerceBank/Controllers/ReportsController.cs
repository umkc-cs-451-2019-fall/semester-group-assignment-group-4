using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommerceBank.Models;
using Microsoft.Data.SqlClient;
using Apache.NMS.ActiveMQ.Commands;
using OfficeOpenXml;
using System.Data;

namespace CommerceBank.Controllers
{
    public class ReportsController: ControllerBase
    {
        private readonly ILogger<ReportsController> _logger;
        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ReportsAlertModel> GetClientAlertsIDAndName()
        {
            var AlertsList = new List<ReportsAlertModel>();
            
            using (var connection = new SqlConnection("Server=.; Database=CCG4; Trusted_Connection=True;"))
            {
               
               connection.Open();
                using (var command = new SqlCommand("[dbo].[spGET_Account_Alert_NamesAndID]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int).Value = 211111110; //TODO: This is harded coded in worst case
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var initialData = new ReportsAlertModel();
                            initialData.AlertName = Convert.ToString(reader["AlertName"]);
                            initialData.AlertsID = Convert.ToInt32(reader["AlertsID"]);

                            AlertsList.Add(initialData);
                        }
                    }
                }
            }
            
            return AlertsList.ToArray();
        }

        [HttpGet]
        public IEnumerable<TransactionModel> GetSelectedAlertsTransactions(int id)
        {
            var transactionDataInitial = new List<TransactionModel>();

            using (var connection = new SqlConnection("Server=.; Database=CCG4; Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spGet_AlertTransactions]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id; 
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var initialData = new TransactionModel();
                            
                            initialData.TransactionId = Convert.ToInt32(reader["TransactionID"]);

                            initialData.TransactionAmount = Convert.ToDecimal(reader["TransactionAmount"]);

                            initialData.TransactionDate = Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd");

                            initialData.TransactionDescription = reader["TransactionDetails"].ToString();

                            initialData.TransactionType = reader["TransactionType"].ToString();

                            transactionDataInitial.Add(initialData);
                        }
                    }
                }
            }
            return transactionDataInitial.ToArray();
        }

        [HttpGet]
        public ActionResult DownloadTransactionReport(int id)
        {
            var dataTable = new DataTable();
            using (var connection = new SqlConnection("Server=.; Database=CCG4; Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spGet_AlertTransactions_ForExporting]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = id;
                    using (var reader = command.ExecuteReader())
                    {
                        dataTable.Load(reader); //Currently there is a defect with exporting the date, it does not come out right
                    }
                }
            }
            byte[] file;
            using (ExcelPackage package = new ExcelPackage())
            {
                package.Workbook.Properties.Author = "CommerceBank";
                package.Workbook.Properties.Title = "Transaction Alert";
                package.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Transaction Report");
                worksheet.Cells["A1"].LoadFromDataTable(dataTable, true);
                int numOfColumns = worksheet.Dimension.End.Column;
                var columnRange = "A1:" +((char)(64 + numOfColumns)).ToString() + "1";
                worksheet.Cells[columnRange].Style.Font.Bold = true;
                worksheet.Cells[columnRange].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thick;
                for(int i = 1; i <= numOfColumns; i++)
                { worksheet.Column(i).Width = 25; }

                file = package.GetAsByteArray();
            }
            return File(file,"application/vnd.ms-excel","Transaction Report.xlsx");
        }
    }
}
