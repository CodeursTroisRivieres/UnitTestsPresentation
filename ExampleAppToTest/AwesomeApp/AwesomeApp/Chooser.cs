using System;
using CellNinja.Parser.Extractors;

namespace AwesomeApp
{
    public class Chooser
    {
        public void Ask()
        {
            Console.WriteLine("Que voulez-vous faire?");
            Console.WriteLine("1- Extraire des nombres");
            Console.WriteLine();
            Console.Write("Entrez votre choix: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    ExtractNumbers();
                    break;

                default:
                    break;
            }
        }

        public void ExtractNumbers()
        {
            Console.WriteLine("Entrez des nombres séparés par une virgule");
            var numbers = Console.ReadLine();

            INumberExtractor numberExtractor = new NumberExtractor();
            var result = numberExtractor.GetIntegers(numbers);
            Console.WriteLine();
            Console.WriteLine("Vous avez entré les nombres suivant :");
            Console.WriteLine(string.Join(" - ", result));
        }
    }
}
