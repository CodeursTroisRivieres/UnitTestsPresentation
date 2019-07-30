using System.Collections.Generic;
using System.Threading.Tasks;
using CellNinja.MovieSearch.Models;

namespace CellNinja.MovieSearch.Repos
{
    public interface IMovieRepo
    {
        Task<IEnumerable<Movie>> SearchAsync(string search);
    }
}
