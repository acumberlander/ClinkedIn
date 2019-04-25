using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class InterestRepository
    {
        public static List<ClinkerInterests> _ClinkerInterests = new List<ClinkerInterests>();

        public static List<Interests> _interests = new List<Interests>();

        const string ConnectionString = "Server = localhost; Database = ClinkedIn; Trusted_Connection = True;";

        //public static Interest AddInterest(string name, int clinkerId)
        //{
            //var newInterest = new Interest() { Name = name, ClinkerId = clinkerId };

            //newInterest.Id = _interests.Count + 1;

            //_interests.Add(newInterest);

            //return newInterest;
        //}

        public static List<ClinkerInterests> GetAllClinkerInterests()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var getAllClinkerInterestsCommand = connection.CreateCommand();
                getAllClinkerInterestsCommand.CommandText = @"select ci.Id, ci.ClinkerId, ci.InterestId 
                                                        from clinkerInterests ci";

                var reader = getAllClinkerInterestsCommand.ExecuteReader();

                while (reader.Read()) {
                    var id = (int)reader["Id"];
                    var clinkerId = (int)reader["ClinkerId"];
                    var interestId = (int)reader["InterestId"];

                    var newClinkerInterest = new ClinkerInterests() { Id = id, ClinkerId = clinkerId, InterestId = interestId };
                    _ClinkerInterests.Add(newClinkerInterest);
                }
            }

            return _ClinkerInterests;
        }

        public static List<Interests> GetAllInterests()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var getAllInterestsCommand = connection.CreateCommand();
                getAllInterestsCommand.CommandText = @"select i.Id, i.Name
                                                        from interests i";

                var reader = getAllInterestsCommand.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var interestName = reader["Name"].ToString();

                    var newInterest = new Interests() { Id = id, Name = interestName };
                    _interests.Add(newInterest);
                }
            }

            return _interests;
        }

        //public static List<Interest> DeleteInterest(int interestId)
        //{
        //var interestToDelete = _interests.First(interest => interest.Id == interestId);

        //_interests.Remove(interestToDelete);

        //return _interests;
        // }

        //public static Interest UpdateInterest(Interest newInterest)
        //{
        //var interestObject = _interests.First(interest => interest.Id == newInterest.Id);

        //interestObject.ClinkerId = newInterest.ClinkerId;
        //interestObject.Name = newInterest.Name;

        //return interestObject;

        //}

    }
}
