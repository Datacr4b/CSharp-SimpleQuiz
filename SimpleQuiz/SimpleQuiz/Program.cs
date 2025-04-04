using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQuiz
{
    internal class Program
    {
        private static string[] quizQuestionsGov = { 
        "Government should not censor speech, press, or internet content directly or indirectly.",
        "Adults should have full bodily autonomy, meaning government should not interfere with decisions affecting their bodies",
        "Government should not monitor personal conversations, correspondence, or search private property without a warrant",
        "There should be no laws against public assembly nor government control of peaceful private association.",
        "Law enforcement should focus resources on crimes against innocent persons and property instead of victimless crimes."
        };

        private static string[] quizQuestionsEco = {
        "Government should stay out of healthcare, allowing people to form and choose health plans, associations, and charities freely.",
        "Let parents educate their children according to their beliefs and preferences, free from government interference.",
        "Replace government welfare with private charity and mutual aid.",
        "Central banks should be abolished, allowing people to freely choose and exchange their preferred currencies.",
        "Lift government restrictions on economic activity and enable courts to adjudicate civil and criminal law violations."
        };

        private static (double auth, double econ) score;
        private static string input;
        private static bool part;
        static void Main(string[] args)
        {
            part = true;
            QuestionForLoop(quizQuestionsGov); // Government Questions 
            part = false;
            QuestionForLoop(quizQuestionsEco); // Economy Questions


            Console.WriteLine("Authoritarian: " + score.auth + " Economy: " + score.econ);

            if (score.auth < 0 && score.econ < 0)
                Console.WriteLine("You're Libertarian");
            else if (score.auth < 0 && score.econ > 0)
                Console.WriteLine("You're Progressive/Socialist");
            else if (score.auth > 0 && score.econ < 0)
                Console.WriteLine("You're Conservative");
            else if (score.auth > 0 && score.econ > 0)
                Console.WriteLine("You're Communist");
            else if (score.auth == 0 && score.econ == 0)
                Console.WriteLine("You're Centrist");
            Console.ReadLine();
        }

        static void QuizScore(string input)
        {
            if (part)
            {
                switch (input)
                {
                    case "a":
                        score.auth -= 1;
                        break;
                    case "m":
                        score.auth -= 0.5;
                        break;
                    case "d":
                        score.auth += 1;
                        break;
                    default:
                        Console.WriteLine("Incorrect Input");
                        break;
                }
            }
            else
            {
                switch (input)
                {
                    case "a":
                        score.econ -= 1;
                        break;
                    case "m":
                        score.econ -= 0.5;
                        break;
                    case "d":
                        score.econ += 1;
                        break;
                    default:
                        Console.WriteLine("Incorrect Input");
                        break;
                }
            }
        }

        static void QuestionLoop(int index, string[] list)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(list[index]);
                Console.WriteLine("Agree (a) Maybe (m) Disagree (d): ");
                input = Console.ReadLine();
                if (input.All(char.IsLetter) && input.ToLower() == "a" || input.ToLower() == "m" || input.ToLower() == "d" )
                {
                    QuizScore(input.ToLower());
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect Input");
                    Console.ReadLine();
                }
            }
        }

        static void QuestionForLoop(string[] list)
        {
            for (int i = 0; i < list.Length; i++) 
            {
                QuestionLoop(i, list);
            }
        }
    }
}
