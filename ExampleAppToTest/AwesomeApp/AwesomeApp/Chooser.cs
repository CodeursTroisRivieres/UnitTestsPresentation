using System;
using System.Linq;
using System.Threading.Tasks;
using CellNinja.MovieSearch.Repos;

namespace AwesomeApp
{
    public class Chooser
    {
        public Chooser(IMovieRepo movieRepo)
        {
            MovieRepo = movieRepo;
        }

        private IMovieRepo MovieRepo { get; set; }

        public async Task AskAsync()
        {
            Console.Clear();
            Console.WriteLine("Que voulez-vous faire?");
            Console.WriteLine("1- Chercher un film");
            Console.WriteLine("2- Lire la description d'un film");
            Console.WriteLine();
            Console.Write("Entrez votre choix: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (choice)
            {
                case '1':
                    Console.Clear();
                    Console.Write("Tapez votre recherche: ");
                    var search = Console.ReadLine();

                    var movies = await MovieRepo.SearchAsync(search);
                    Console.WriteLine();
                    Console.WriteLine(string.Join(Environment.NewLine, movies.Select(m => $"{m.Title} ({m.ImdbID})")));

                    Console.WriteLine();
                    Console.Write("Appuyez sur une touche pour recommencer");
                    Console.Read();
                    break;

                default:
                    return;
            }

            await AskAsync();
        }
    }
}
