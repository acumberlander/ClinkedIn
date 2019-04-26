using ClinkedIn.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ClinkedIn.Data
{
    static class ServiceRepository
    {
        public static List<ClinkerServices> _ClinkerServices = new List<ClinkerServices>();

        public static List<Services> _services = new List<Services>();

        const string ConnectionString = "Server = localhost; Database = ClinkedIn; Trusted_Connection = True;";

        public static List<ClinkerServices> GetAllClinkerServices()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var getAllClinkerServicesCommand = connection.CreateCommand();
                getAllClinkerServicesCommand.CommandText = @"select cs.Id, cs.ClinkerId, cs.ServiceId 
                                                             from clinkerServices cs";

                var reader = getAllClinkerServicesCommand.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var clinkerId = (int)reader["ClinkerId"];
                    var serviceId = (int)reader["ServiceId"];

                    var newClinkerService = new ClinkerServices() { Id = id, ClinkerId = clinkerId, ServiceId = serviceId };
                    _ClinkerServices.Add(newClinkerService);
                }
            }

            return _ClinkerServices;
        }

        public static List<Services> GetAllServices()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var getAllServicesCommand = connection.CreateCommand();

                getAllServicesCommand.CommandText = @"select s.Id, s.ServiceName, s.Description, s.Price
                                                      from services s";

                var reader = getAllServicesCommand.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var serviceName = reader["ServiceName"].ToString();
                    var description = reader["Description"].ToString();
                    var price = (decimal)reader["Price"];

                    var newService = new Services() { Id = id, ServiceName = serviceName, Description = description, Price = price };
                    _services.Add(newService);
                }
            }
            return _services;
        }
    }
}
