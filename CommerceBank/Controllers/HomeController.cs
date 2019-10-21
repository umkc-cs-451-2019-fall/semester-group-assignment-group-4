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
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController: ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This function will return an enumerable array to the Home page that will have the 
        /// Initial load data for the table that is displayed
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TransactionModel> GetInitialLoadTransactionData()
        {
            var transactionDataInitial = new List<TransactionModel>();

            //TransactionModel transactionDataInitial = new TransactionModel();

            var initialData = new TransactionModel();

            using (var connection = new SqlConnection("Server=.; Database=CCG4; Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spGET_ALL_TransactionTable_Data_BasedOnAccountID]", connection))
                {

                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int).Value = 211111110;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Throwing DBNull exceptions
                            //either fill all nulls in table or create a way to check and override the exception
                            // that wont mess up the resulting rendering of the query diplay in the API
                            initialData.TransactionId = Convert.ToInt32(reader["TransactionId"]);

                            initialData.TransactionAmount = Convert.ToDecimal(reader["TransactionAmount"]);

                            initialData.TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);

                            initialData.TransactionDescription = reader["TransactionDescription"].ToString();

                            initialData.TransactionType = reader["TransactionType"].ToString();

                            initialData.AccountBalance = Convert.ToDecimal(reader["AccountBalance"]);

                            transactionDataInitial.Add(initialData);
                        }

                        
                    }
                }
            }

            return transactionDataInitial.ToArray();
        }
        
    }
}
