using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronote
{
    public class Student : User, ILogin
    {
        public bool Authenticate(string username, string password)
        {
            return this.Username == username && this.Password == password;
        }
        public static void StudentMenu(Student student, List<Rating> ratings)
        {
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu Élève");
                Console.WriteLine("1. Afficher mes notes");
                Console.WriteLine("2. Déconnexion");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowStudentRatings(student, ratings);
                        break;
                    case 2:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            } while (!exit);
        }
        public static void ShowStudentRatings(Student student, List<Rating> ratings)
        {
            Console.Clear();
            Console.WriteLine("Vos notes :");

            foreach (var rating in ratings)
            {
                if (rating.StudentUsername == student.Username)
                {
                    Console.WriteLine($"Cours : {rating.CourseName}, Note : {rating.Value}");
                }
            }

            Console.ReadLine();
        }
    }

}
