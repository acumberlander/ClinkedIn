using ClinkedIn.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ClinkedIn.Data
{
    public class ClinkerRepository
    {
        public static List<Clinker> _clinkers = new List<Clinker>
        {
            new Clinker(1, "Larry", "lardog111", 34, true, new DateTime(2019, 4, 14)),
            new Clinker(2, "Gary", "garyisthebest", 26, true, new DateTime(2065, 5, 4)),
            new Clinker(3, "Barry", "theflash420", 54, true, new DateTime(2099, 2, 21)),
            new Clinker(4, "Jerry", "jhd8434", 19, false, new DateTime(2056, 8, 10)),
            new Clinker(5, "Perry", "italy293", 27, true, new DateTime(2045, 6, 11))
        };

        public Clinker AddClinker(string name, string password, int age, bool isPrisoner, DateTime releaseDate)
        {
            var newClinker = new Clinker(name, password, age, isPrisoner, releaseDate);

            newClinker.Id = _clinkers.Count + 1;

            _clinkers.Add(newClinker);

            return newClinker;
        }

        //Method to get the clinkers, to be called in the controllers
        public List<Clinker> GetAllClinkers()
        {
            var clinkers = new List<Clinker>();

            var connection = new SqlConnection("Server=localhost;Database=ClinkedIn;Trusted_Connection=True;");
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

        public static HashSet<Clinker> FindPotentialFriends(int clinkerId)
        {
            //filter _interest list by clinkerId.
            HashSet<Interests> userInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == clinkerId).ToHashSet();

            //separate users who are not your friends.
            HashSet<Friendship> yourFriendships = FriendshipRepository._friends.Where(friendship => friendship.ClinkerOneId == clinkerId || friendship.ClinkerTwoId == clinkerId).ToHashSet();
            HashSet<Clinker> notYourFriends = new HashSet<Clinker>();

            foreach (var prisoner in _clinkers)
            {
                foreach (var friendship in yourFriendships)
                {
                    if (prisoner.Id != friendship.ClinkerOneId && prisoner.Id != friendship.ClinkerTwoId)
                    {
                        notYourFriends.Add(prisoner);
                    }
                }
            }

            //find prisoners with simalar interests
            var potentialFriendsList = new HashSet<Clinker>();

            foreach (var prisoner in notYourFriends)
            {
                List<Interests> prisonerInterest = InterestRepository._interests.Where(interest => interest.ClinkerId == prisoner.Id).ToList();

                foreach (var interest in prisonerInterest)
                {
                    foreach (var clinkerInterest in userInterest)
                    {
                        if (clinkerInterest.Name == interest.Name)
                        {
                            potentialFriendsList.Add(prisoner);
                            break;
                        }
                    }
                }
            }

            return potentialFriendsList;
        }
    }
}
