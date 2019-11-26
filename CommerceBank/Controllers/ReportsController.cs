using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommerceBank.Models;
using Microsoft.Data.SqlClient;
using Apache.NMS.ActiveMQ.Commands;

namespace CommerceBank.Controllers
{
    public class ReportsController: ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public ReportsController(ILogger<HomeController> logger)
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
                            //Throwing DBNull exceptions
                            //either fill all nulls in table or create a way to check and override the exception
                            // that wont mess up the resulting rendering of the query diplay in the API
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
                            //Throwing DBNull exceptions
                            //either fill all nulls in table or create a way to check and override the exception
                            // that wont mess up the resulting rendering of the query diplay in the API
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
    }
}
