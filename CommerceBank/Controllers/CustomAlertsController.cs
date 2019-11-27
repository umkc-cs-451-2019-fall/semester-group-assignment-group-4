using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommerceBank.Models;
using Microsoft.Data.SqlClient;


namespace CommerceBank.Controllers
{
    public class CustomAlertsController: ControllerBase
    {
        private readonly ILogger<CustomAlertsController> _logger;
        public CustomAlertsController(ILogger<CustomAlertsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AlertFiltersModel> GetAlertFiltersAndIDs()
        {
            var alertFiltersList = new List<AlertFiltersModel>();

            using (var connection = new SqlConnection("Server=.; Database=CCG4; Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spGET_AlertFilters]", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var initialData = new AlertFiltersModel();
                            initialData.AlertFilter = Convert.ToString(reader["AlertFilter"]);
                            initialData.ID = Convert.ToInt32(reader["ID"]);

                            alertFiltersList.Add(initialData);
                        }
                    }
                }
            }
            return alertFiltersList.ToArray();
        }

        [HttpGet]
        public IEnumerable<ReportsAlertModel> DeleteAlert(string ID)
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
    }
}
