using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Data
{
    static class InterestRepository
    {
        public static List<ClinkerInterests> _clinkerInterests = new List<ClinkerInterests>();

        public static List<Interests> _interests = new List<Interests>();

        const string ConnectionString = "Server = localhost; Database = ClinkedIn; Trusted_Connection = True;";

        public static Interests AddInterest(Interests interestObject)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var insertInterestCommand = connection.CreateCommand();
                insertInterestCommand.CommandText = @"Insert into interests (name)
                                                      Output inserted.*
                                                      Values(@name)";

                insertInterestCommand.Parameters.AddWithValue("name", interestObject.Name);

                var reader = insertInterestCommand.ExecuteReader();

                if (reader.Read())
                {
                    var InsertedId = (int)reader["Id"];
                    var InsertedName = reader["Name"].ToString();

                    var newInterest = new Interests() { Id = InsertedId, Name = InsertedName };
                    return newInterest;
                }
            }
            throw new Exception("No interest found");
        }

        public static ClinkerInterests AddClinkerInterest(ClinkerInterests clinkerInterestObject)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var insertClinkerInterestCommand = connection.CreateCommand();
                insertClinkerInterestCommand.CommandText = @"Insert into clinkerinterests (interestId, clinkerId)
                                                      Output inserted.*
                                                      Values(@interestId, @clinkerId)";

                insertClinkerInterestCommand.Parameters.AddWithValue("interestId", clinkerInterestObject.InterestId);
                insertClinkerInterestCommand.Parameters.AddWithValue("clinkerId", clinkerInterestObject.ClinkerId);

                var reader = insertClinkerInterestCommand.ExecuteReader();

                if (reader.Read())
                {
                    var InsertedId = (int)reader["Id"];
                    var InsertedInterestId = (int)reader["InterestId"];
                    var InsertedClinkerId = (int)reader["ClinkerId"];

                    var newClinkerInterest = new ClinkerInterests() { Id = InsertedId, InterestId = InsertedInterestId, ClinkerId = InsertedClinkerId };
                    return newClinkerInterest;
                }
            }
            throw new Exception("No clinker interest found");
        }

        public static List<ClinkerInterests> GetAllClinkerInterests()
        {
            _clinkerInterests = new List<ClinkerInterests>();

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
                    _clinkerInterests.Add(newClinkerInterest);
                }
            }

            return _clinkerInterests;
        }

        public static List<Interests> GetAllInterests()
        {
            _interests = new List<Interests>();

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

        public static List<Interests> DeleteInterest(int interestId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var deleteInterestCommand = connection.CreateCommand();
                deleteInterestCommand.CommandText = @"Delete from interests
                                                    where Id = @interestId";

                deleteInterestCommand.Parameters.AddWithValue("interestId", interestId);

                deleteInterestCommand.ExecuteNonQuery();
            }

            var getAllInterestsList = GetAllInterests();
            return getAllInterestsList;
        }

        public static List<ClinkerInterests> DeleteClinkerInterest(int clinkerInterestId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var deleteClinkerInterestCommand = connection.CreateCommand();
                deleteClinkerInterestCommand.CommandText = @"Delete from ClinkerInterests
                                                    where Id = @clinkerInterestId";

                deleteClinkerInterestCommand.Parameters.AddWithValue("clinkerInterestId", clinkerInterestId);

                deleteClinkerInterestCommand.ExecuteNonQuery();
            }

            var getAllClinkerInterestsList = GetAllClinkerInterests();
            return getAllClinkerInterestsList;
        }

        public static Interests UpdateInterest(Interests newInterest)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var updateInterestCommand = connection.CreateCommand();
                updateInterestCommand.CommandText = @"Update Interests
                                                            set Name = @name
                                                            where id = @interestId";

                updateInterestCommand.Parameters.AddWithValue("interestId", newInterest.Id);
                updateInterestCommand.Parameters.AddWithValue("name", newInterest.Name);

                updateInterestCommand.ExecuteNonQuery();

                var updatedInterestObject = GetInterestById(newInterest.Id);

                return updatedInterestObject;

            }
            throw new Exception("No clinker interest found");
        }

        public static Interests GetInterestById(int interestId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var getInterestCommand = connection.CreateCommand();
                getInterestCommand.CommandText = @"select i.Id, i.Name
                                                      from interests i
                                                      where i.Id = @interestId";

                getInterestCommand.Parameters.AddWithValue("interestId", interestId);

                var reader = getInterestCommand.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var interestName = reader["Name"].ToString();

                    var newInterest = new Interests() { Id = id, Name = interestName };
                    return newInterest;
                }

                throw new Exception("Interest not found");
            }
        }

        public static ClinkerInterests UpdateClinkerInterest(ClinkerInterests newClinkerInterest)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var updateClinkerInterestCommand = connection.CreateCommand();
                updateClinkerInterestCommand.CommandText = @"Update ClinkerInterests
                                                            set clinkerId = @clinkerId, interestId = @interestId
                                                            where id = @clinkerInterestId";
                
                updateClinkerInterestCommand.Parameters.AddWithValue("interestId", newClinkerInterest.InterestId);
                updateClinkerInterestCommand.Parameters.AddWithValue("clinkerId", newClinkerInterest.ClinkerId);
                updateClinkerInterestCommand.Parameters.AddWithValue("clinkerInterestId", newClinkerInterest.Id);

                updateClinkerInterestCommand.ExecuteNonQuery();

                var updatedClinkerInterestObject = GetClinkerInterestById(newClinkerInterest.Id);

                return updatedClinkerInterestObject;

            }
            throw new Exception("No clinker interest found");
        }

        public static ClinkerInterests GetClinkerInterestById(int clinkerInterestId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var getClinkerInterestCommand = connection.CreateCommand();
                getClinkerInterestCommand.CommandText = @"select ci.Id, ci.ClinkerId, ci.InterestId
                                                      from ClinkerInterests ci
                                                      where ci.Id = @clinkerInterestId";

                getClinkerInterestCommand.Parameters.AddWithValue("clinkerInterestId", clinkerInterestId);

                var reader = getClinkerInterestCommand.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var interestId = (int)reader["InterestId"];
                    var clinkerId = (int)reader["ClinkerId"];

                    var newClinkerInterest = new ClinkerInterests() { Id = id, ClinkerId = clinkerId, InterestId = interestId };
                    return newClinkerInterest;
                }

                throw new Exception("Interest not found");
            }
        }

    }
}
