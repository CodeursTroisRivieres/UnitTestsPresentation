using System.Collections.Generic;

namespace CellNinja.MovieSearch.Models
{
    public class OmdbResult
    {
        public List<Movie> Search { get; set; }
        public string TotalResults { get; set; }
        public string Response { get; set; }
    }
}
