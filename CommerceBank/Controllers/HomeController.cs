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
                using (var command = new SqlCommand("[dbo].[spGet_TransactionData]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = 1;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //Throwing DBNull exceptions
                            //either fill all nulls in table or create a way to check and override the exception
                            // that wont mess up the resulting rendering of the query diplay in the API
                            var item = reader["AMOUNT"];
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
