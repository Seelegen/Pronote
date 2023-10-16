using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Pronote
{
    public static class DataManagement
    {
        private const string UsersFilePath = "users.json";
        private const string RatingsFilePath = "ratings.json";

        public static List<User> LoadUsers()
        {
            if (File.Exists(UsersFilePath))
            {
                string json = File.ReadAllText(UsersFilePath);
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
            return new List<User>();
        }

        public static void SaveUsers(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(UsersFilePath, json);
        }

        public static List<Rating> LoadRatings()
        {
            if (File.Exists(RatingsFilePath))
            {
                string json = File.ReadAllText(RatingsFilePath);
                return JsonConvert.DeserializeObject<List<Rating>>(json);
            }
            return new List<Rating>();
        }

        public static void SaveRatings(List<Rating> ratings)
        {
            string json = JsonConvert.SerializeObject(ratings);
            File.WriteAllText(RatingsFilePath, json);
        }
    }
}
