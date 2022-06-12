using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpBuster.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(75)]
        public string Name { get; set; }
        [StringLength(75)]

        public string Director { get; set; }
        [Required]
        [DisplayName("Release Date")]
        public string ReleaseDate { get; set; }
        //Navigation props
        public List<MovieClient> MovieClients { get; set; }
    }
}
