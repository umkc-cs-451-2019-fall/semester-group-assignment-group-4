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
                account = "411111111",
                amount = "-200.00",
                date = "11/02/16",
                details = "Verizon",
                action = 1
            };
            TransactionModel T2 = new TransactionModel
            {
                id = 2,
                account = "411111111",
                amount = "-18.24",
                date = "11/02/16",
                details = "Panda Express",
                action = 1
            };
            TransactionModel T3 = new TransactionModel
            {
                id = 3,
                account = "411111111",
                amount = "-64.03",
                date = "11/02/16",
                details = "CVS",
                action = 1
            };
            TransactionModel T4 = new TransactionModel
            {
                id = 4,
                account = "411111111",
                amount = "-122.08",
                date = "11/02/16",
                details = "Maurices",
                action = 1
            };
            TransactionModel T5 = new TransactionModel
            {
                id = 5,
                account = "411111111",
                amount = "-26.11",
                date = "11/02/16",
                details = "QuikTrip",
                action = 1
            };
           

            // Rename these later - KH
            List<TransactionModel> MockTransactionData = new List<TransactionModel>();
           
            MockTransactionData.Add(T1);
            MockTransactionData.Add(T2);
            MockTransactionData.Add(T3);
            MockTransactionData.Add(T4);
            MockTransactionData.Add(T5);
        
            return MockTransactionData.ToArray();
        }



        public IEnumerable<TransactionModel> GetSavingsLoadTransactionData()
        {
            
            TransactionModel T6 = new TransactionModel
            {
                id = 6,
                account = "8222222228",
                amount = "25.00",
                date = "11/01/16",
                details = "Cash Deposit",
                action = 0
            };
            TransactionModel T7 = new TransactionModel
            {
                id = 7,
                account = "8222222228",
                amount = "200.00",
                date = "11/16/16",
                details = "Transfer from savings - Mom loves you!!",
                action = 0
            };
            TransactionModel T8 = new TransactionModel
            {
                id = 8,
                account = "8222222228",
                amount = "25.00",
                date = "11/16/16",
                details = "Cash Deposit",
                action = 0
            };
            TransactionModel T9 = new TransactionModel
            {
                id = 9,
                account = "8222222228",
                amount = "100.00",
                date = "11/29/16",
                details = "Transfer from savings",
                action = 0
            };
            TransactionModel T10 = new TransactionModel
            {
                id = 10,
                account = "8222222228",
                amount = "300.00",
                date = "11/30/16",
                details = "Transfer from savings",
                action = 0
            };

            // Rename these later - KH
            List<TransactionModel> MockTransactionData = new List<TransactionModel>();
            
            
            MockTransactionData.Add(T6);
            MockTransactionData.Add(T7);
            MockTransactionData.Add(T8);
            MockTransactionData.Add(T9);
            MockTransactionData.Add(T10);
            return MockTransactionData.ToArray();
        }

    }
}
