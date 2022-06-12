using System.ComponentModel.DataAnnotations;

namespace SharpBuster.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        //Navigation props
        public List<MovieClient> MovieClients { get; set; }
    }
}
