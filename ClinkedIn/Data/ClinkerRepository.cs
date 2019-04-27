using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ClinkedIn.Data
{
    public class ClinkerRepository
    {
        const string ConnectionString = "Server=localhost;Database=ClinkedIn;Trusted_Connection=True;";

        // Add Clinker
        public Clinker AddClinker(string name, string password, int age, bool isPrisoner, DateTime releaseDate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var insertClinkerCommand = connection.CreateCommand();
                insertClinkerCommand.CommandText = $@"Insert into Clinkers(name, password, age, isPrisoner, releaseDate)
                                                        output inserted.*
                                                        values(@name, @password, @age, @isPrisoner, @releaseDate)";

                insertClinkerCommand.Parameters.AddWithValue("name", name);
                insertClinkerCommand.Parameters.AddWithValue("password", password);
                insertClinkerCommand.Parameters.AddWithValue("age", age);
                insertClinkerCommand.Parameters.AddWithValue("isPrisoner", isPrisoner);
                insertClinkerCommand.Parameters.AddWithValue("releaseDate", releaseDate);

                var reader = insertClinkerCommand.ExecuteReader();

                if (reader.Read())
                {
                    var insertedName = reader["name"].ToString();
                    var insertedPassword = reader["password"].ToString();
                    var insertedId = (int)reader["Id"];
                    var insertedAge = (int)reader["age"];
                    var insertedIsPrisoner = (bool)reader["isPrisoner"];
                    var insertedReleaseDate = (DateTime)reader["releaseDate"];

                    var newClinker = new Clinker(insertedName, insertedPassword, insertedAge, insertedIsPrisoner, insertedReleaseDate) { Id = insertedId };

                    return newClinker;
                }
            }
            throw new Exception("No clinker found");
        }

        // Get All Clinkers
        public List<Clinker> GetAllClinkers()
        {
            var clinkers = new List<Clinker>();

            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var getAllClinkersCommand = connection.CreateCommand();
            getAllClinkersCommand.CommandText = @"select name,password,id,age,isPrisoner,releaseDate
                                                    from clinkers";

            var reader = getAllClinkersCommand.ExecuteReader();

            while (reader.Read())
            {
                var id = (int)reader["Id"];
                var name = reader["name"].ToString();
                var password = reader["password"].ToString();
                var age = (int)reader["age"];
                var isPrisoner = (bool)reader["isPrisoner"];
                var releaseDate = (DateTime)reader["releaseDate"];
                var clinker = new Clinker(name, password, age, isPrisoner, releaseDate) { Id = id };

                clinkers.Add(clinker);
            }

            connection.Close();

            foreach (Clinker clinker in clinkers)
            {
                clinker.Interests = getClinkerInterests(clinker.Id);
            }

            return clinkers;
        }

        // Get the interests for each clinker
        public List<String> getClinkerInterests(int clinkerId)
        {
            var interestsList = new List<string>();

            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var getClinkerWithInterestsCommand = connection.CreateCommand();

            getClinkerWithInterestsCommand.Parameters.AddWithValue("@clinkerId", clinkerId);

            getClinkerWithInterestsCommand.CommandText = @"select i.Name
                                                         from Interests i
                                                         join ClinkerInterests ci
                                                         on ci.InterestId = i.Id
                                                         where ci.ClinkerId = @clinkerId";


            var reader = getClinkerWithInterestsCommand.ExecuteReader();

            while (reader.Read())
            {
                var name = reader["name"].ToString();

                interestsList.Add(name);
            }

            connection.Close();

            return interestsList;
        }

        // Delete Clinker
        public List<Clinker> DeleteClinker(int clinkerId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var deleteClinkerCommand = connection.CreateCommand();


                deleteClinkerCommand.CommandText = @"Delete from clinkers
                                                     where Id = @clinkerId";

                deleteClinkerCommand.Parameters.AddWithValue("clinkerId", clinkerId);

                deleteClinkerCommand.ExecuteNonQuery();
            }

            var getAllClinkersAgain = GetAllClinkers();
            return getAllClinkersAgain;
        }

        // Update Clinker
        public bool UpdateClinker(int clinkerId, string name, string password, int age, bool isPrisoner, DateTime releaseDate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var updateClinkerCommand = connection.CreateCommand();

                updateClinkerCommand.Parameters.AddWithValue("@clinkerId", clinkerId);

                updateClinkerCommand.CommandText = @"update clinkers
                                                     set name = @name,
                                                     password = @password,
                                                     age = @age,
                                                     isPrisoner = @isPrisoner,
                                                     releaseDate = @releaseDate
                                                     where id = @clinkerId";
                
                updateClinkerCommand.Parameters.AddWithValue("name", name);
                updateClinkerCommand.Parameters.AddWithValue("password", password);
                updateClinkerCommand.Parameters.AddWithValue("age", age);
                updateClinkerCommand.Parameters.AddWithValue("isPrisoner", isPrisoner);
                updateClinkerCommand.Parameters.AddWithValue("releaseDate", releaseDate);

                var numberOfRowsUpdated = updateClinkerCommand.ExecuteNonQuery();

                connection.Close();

                if(numberOfRowsUpdated > 0)
                {
                    return true;
                }
                return false;

            }

        }
    }
}
