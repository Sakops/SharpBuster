namespace SharpBuster.Models
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Client> Clients { get; set; }
        public List<MovieClient> MovieClients { get; set; }
    }
}
