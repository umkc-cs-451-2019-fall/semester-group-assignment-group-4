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

            using (var connection = new SqlConnection("Server=.\\CCG4; Database=CCG4; Trusted_Connection=True;"))
            {
                connection.Open();
                string sql = "SELECT * FROM Transactions";
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Throwing DBNull exceptions
                            //either fill all nulls in table or create a way to check and override the exception
                            // that wont mess up the resulting rendering of the query diplay in the API
                            initialData.TransactionId = Convert.ToInt32(reader["TransactionId"]);

                            initialData.TransactionAmount = Convert.ToInt32(reader["TransactionAmount"]);

                            initialData.TransactionDate = Convert.ToDateTime(reader["TransactionDate"]);

                            initialData.TransactionDescription = reader["TransactionDescription"].ToString();       

                            transactionDataInitial.Add(initialData);
                        }

                        
                    }
                }
            }

            return transactionDataInitial.ToArray();
        }
        
    }
}
