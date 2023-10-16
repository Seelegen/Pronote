using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronote
{
    public class Teacher : User, ILogin
    {
        public bool Authenticate(string username, string password)
        {
            return this.Username == username && this.Password == password;
        }

        public static void TeacherMenu(Teacher teacher, List<Rating> ratings, List<Student> students, List<Course> courses)
        {
            bool exit = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Menu Professeur");
                Console.WriteLine("1. Afficher les notes");
                Console.WriteLine("2. Ajouter une note");
                Console.WriteLine("3. Déconnexion");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Affichage des notes...");
                        Console.ReadLine();
                        break;
                    case 2:
                        Rating.AddRating(teacher, ratings, students, courses);
                        break;
                    case 3:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            } while (!exit);
        }
    }
}
