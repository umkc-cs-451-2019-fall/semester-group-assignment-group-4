using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommerceBank.Models;

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
            TransactionModel T1 = new TransactionModel
            {

                id = 1,
                account = 211111110,
                amount = 20.99,
                date = DateTime.Now.ToString("d"),
                details = "UMKC SU"
            };
            TransactionModel T2 = new TransactionModel
            {
                id = 2,
                account = 411111111,
                amount = 50.99,
                date = DateTime.Now.ToString("d"),
                details = "Internet Provider"
            };
            List<TransactionModel> MockTransactionData = new List<TransactionModel>();
            MockTransactionData.Add(T1);
            MockTransactionData.Add(T2);
            return MockTransactionData.ToArray();
        }
    }
}
