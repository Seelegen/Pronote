using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pronote.User;
using Pronote;

namespace Pronote
{
    class Program
    {
        static void Main()
        {
            List<User> users = DataManagement.LoadUsers();
            List<Rating> ratings = DataManagement.LoadRatings();
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            bool loggedIn = false;
            User currentUser = null;

            do
            {
                Console.Clear();
                Console.WriteLine("1. Connexion");
                Console.WriteLine("2. Créer un compte");
                Console.WriteLine("3. Quitter");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        currentUser = AuthenticateUser(users);
                        if (currentUser != null)
                        {
                            loggedIn = true;
                            Console.WriteLine($"Bienvenue, {currentUser.Username}!");
                            Console.ReadLine();

                            if (currentUser is Teacher)
                            {
                                Teacher.TeacherMenu((Teacher)currentUser, ratings, students, courses);
                            }
                            else if (currentUser is Student)
                            {
                                Student.StudentMenu((Student)currentUser, ratings);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nom d'utilisateur ou mot de passe incorrect.");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        CreateUser(users);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            } while (!loggedIn);
        }
    }
}

