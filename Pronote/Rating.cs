using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronote
{
    public class Rating
    {
        public string StudentUsername { get; set; }
        public string CourseName { get; set; } // Ajout de la propriété CourseName
        public double Value { get; set; }

        public static void AddRating(Teacher teacher, List<Rating> ratings, List<Student> students, List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("Ajouter une note");

            Console.WriteLine("Liste des élèves :");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {students[i].Username}");
            }

            Console.Write("Entrez le nom d'utilisateur de l'élève : ");
            string studentUsername = Console.ReadLine();

            Student selectedStudent = students.FirstOrDefault(s => s.Username == studentUsername);

            if (selectedStudent != null)
            {
                Console.WriteLine("Liste des cours :");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].Name}");
                }

                Console.Write("Choisissez un cours (numéro) : ");
                int courseIndex = int.Parse(Console.ReadLine());

                if (courseIndex >= 1 && courseIndex <= courses.Count)
                {
                    Console.Write("Note : ");
                    double value = double.Parse(Console.ReadLine());

                    Rating newRating = new Rating
                    {
                        StudentUsername = selectedStudent.Username,
                        CourseName = courses[courseIndex - 1].Name,
                        Value = value
                    };

                    ratings.Add(newRating);
                    DataManagement.SaveRatings(ratings);

                    Console.WriteLine("Note ajoutée avec succès!");
                }
                else
                {
                    Console.WriteLine("Numéro de cours invalide. Veuillez réessayer.");
                }
            }
            else
            {
                Console.WriteLine("Aucun élève trouvé avec ce nom d'utilisateur. Veuillez réessayer.");
            }

            Console.ReadLine();
        }
    }
}
