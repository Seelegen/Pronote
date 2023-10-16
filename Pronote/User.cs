using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronote
{
        public class User
        {
            public string Username { get; set; }
            public string Password { get; set; }
            public PronoteUserType UserType { get; set; }

            public enum PronoteUserType
            {
                Student,
                Teacher
            }

            public static  User AuthenticateUser(List<User> users)
            {
            Console.Clear();
            Console.Write("Nom d'utilisateur : ");
            string username = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string password = Console.ReadLine();

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }

            public static void CreateUser(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("Création de compte");
            Console.Write("Nom d'utilisateur : ");
            string username = Console.ReadLine();
            Console.Write("Mot de passe : ");
            string password = Console.ReadLine();

            if (users.Any(u => u.Username == username))
            {
                Console.WriteLine("Ce nom d'utilisateur existe déjà. Veuillez en choisir un autre.");
                Console.ReadLine();
                return;
            }

            Console.Write("Type de compte (1 pour Professeur, 2 pour Élève) : ");
            int userType = int.Parse(Console.ReadLine());

            User newUser;

            if (userType == 1)
            {
                newUser = new Teacher { Username = username, Password = password };
                newUser.UserType = PronoteUserType.Teacher;
            }
            else if (userType == 2)
            {
                newUser = new Student { Username = username, Password = password };
                newUser.UserType = PronoteUserType.Student;
            }
            else
            {
                Console.WriteLine("Type de compte invalide. Veuillez réessayer.");
                Console.ReadLine();
                return;
            }

            users.Add(newUser);
            DataManagement.SaveUsers(users);

            Console.WriteLine("Compte créé avec succès!");
            Console.ReadLine();
        }
    }
    }
