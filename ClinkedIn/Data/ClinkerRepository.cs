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

        public Clinker AddClinker(string name, string password, int age, bool isPrisoner, DateTime releaseDate)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var insertClinkerCommand = connection.CreateCommand();
                insertClinkerCommand.CommandText = $@"Insert into Clinkers(name, password, age, isPrisoner, releaseDate)
                                                        output inserted.*
                                                        values('{name}', '{password}', '{age}', '{isPrisoner}', '{releaseDate}')";

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

            return clinkers;
        }

        //public static HashSet<Clinker> FindPotentialFriends(int clinkerId)
        //{
        //    //filter _interest list by clinkerId.
        //    HashSet<Interest> userInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == clinkerId).ToHashSet();

        //    //separate users who are not your friends.
        //    HashSet<Friendship> yourFriendships = FriendshipRepository._friends.Where(friendship => friendship.ClinkerOneId == clinkerId || friendship.ClinkerTwoId == clinkerId).ToHashSet();
        //    HashSet<Clinker> notYourFriends = new HashSet<Clinker>();

        //    foreach (var prisoner in _clinkers)
        //    {
        //        foreach (var friendship in yourFriendships)
        //        {
        //            if (prisoner.Id != friendship.ClinkerOneId && prisoner.Id != friendship.ClinkerTwoId)
        //            {
        //                notYourFriends.Add(prisoner);
        //            }
        //        }
        //    }

        //    //find prisoners with simalar interests
        //    var potentialFriendsList = new HashSet<Clinker>();

        //    foreach (var prisoner in notYourFriends)
        //    {
        //        List<Interest> prisonerInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == prisoner.Id).ToList();

        //        foreach (var interest in prisonerInterest)
        //        {
        //            foreach (var clinkerInterest in userInterest)
        //            {
        //                if (clinkerInterest.Name == interest.Name)
        //                {
        //                    potentialFriendsList.Add(prisoner);
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    return potentialFriendsList;
        //}
    }
}
