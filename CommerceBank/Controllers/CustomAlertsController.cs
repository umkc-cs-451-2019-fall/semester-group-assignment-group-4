using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommerceBank.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;

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
                using (var command = new SqlCommand("[dbo].[spDELETE_Account_Alert_NamesAndID]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int).Value = 211111110; //TODO: This is harded coded in worst case
                    command.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value = ID;
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
        public IEnumerable<ReportsAlertModel> PostNewAlert(string Filters, string AlertName)
        {
            var filterParams = JsonConvert.DeserializeObject<List<NewAlertModel>>(Filters);
            SelectedFiltersModel selectedFiltersToPass = createModelToSendToDB(filterParams);
            using (var connection = new SqlConnection("Server=.; Database=CCG4; Trusted_Connection=True;"))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[spInsert_Alert]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@AccountID", System.Data.SqlDbType.Int).Value = 211111110; //TODO: This is harded coded in worst case
                    command.Parameters.Add("@AlertName", System.Data.SqlDbType.NVarChar).Value = AlertName;
                    command.Parameters.Add("@TransactionType", System.Data.SqlDbType.NVarChar).Value = selectedFiltersToPass.TransactionType;
                    command.Parameters.Add("@State", System.Data.SqlDbType.Char).Value = selectedFiltersToPass.State;
                    command.Parameters.Add("@Dispute", System.Data.SqlDbType.Char).Value = selectedFiltersToPass.Dispute ;
                    command.Parameters.Add("@TransactionDetails", System.Data.SqlDbType.NVarChar).Value = selectedFiltersToPass.TransactionDetails;
                    command.Parameters.Add("@GreaterThanAmount", System.Data.SqlDbType.Decimal).Value = selectedFiltersToPass.GreaterThanAmount ;
                    command.Parameters.Add("@LessThanAmount", System.Data.SqlDbType.Decimal).Value = selectedFiltersToPass.LessThanAmount;
                    command.Parameters.Add("@EqualAmount", System.Data.SqlDbType.Decimal).Value = selectedFiltersToPass.EqualAmount;
                    command.Parameters.Add("@AfterThisDate", System.Data.SqlDbType.NVarChar).Value = selectedFiltersToPass.AfterThisDate;
                    command.Parameters.Add("@BeforeThisDate", System.Data.SqlDbType.NVarChar).Value = selectedFiltersToPass.BeforeThisDate;
                    command.Parameters.Add("@ExactDate", System.Data.SqlDbType.NVarChar).Value = selectedFiltersToPass.ExactDate;
                    command.ExecuteReader();
         
                }
            }

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

        /// <summary>
        /// This places the values for us to easily pass them to DB
        /// It does not scale well but gets the job done at the moment
        /// </summary>
        /// <param name="newAlertsList"></param>
        /// <returns></returns>
        private SelectedFiltersModel createModelToSendToDB(List<NewAlertModel> newAlertsList)
        {
            SelectedFiltersModel selectedFiltersModel = new SelectedFiltersModel();
            foreach(NewAlertModel newAlert in newAlertsList)
            {
                if (newAlert.AlertID == 1) { selectedFiltersModel.TransactionType = newAlert.value; }
                else if (newAlert.AlertID == 2) { selectedFiltersModel.State = newAlert.value; }
                else if (newAlert.AlertID == 3) { selectedFiltersModel.Dispute = int.Parse(newAlert.value); }
                else if (newAlert.AlertID == 4) { selectedFiltersModel.TransactionDetails = newAlert.value; }
                else if (newAlert.AlertID == 5) { selectedFiltersModel.GreaterThanAmount = decimal.Parse(newAlert.value); }
                else if (newAlert.AlertID == 6) { selectedFiltersModel.LessThanAmount = decimal.Parse(newAlert.value); }
                else if (newAlert.AlertID == 7) { selectedFiltersModel.EqualAmount = decimal.Parse(newAlert.value); }
                else if (newAlert.AlertID == 8) { selectedFiltersModel.AfterThisDate = newAlert.value; }
                else if (newAlert.AlertID == 9) { selectedFiltersModel.BeforeThisDate = newAlert.value; }
                else if (newAlert.AlertID == 10) { selectedFiltersModel.ExactDate = newAlert.value; }
            }
            return selectedFiltersModel;
        }
    }
}
