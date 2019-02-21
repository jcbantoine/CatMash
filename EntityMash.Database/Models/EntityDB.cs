using System.ComponentModel.DataAnnotations;

namespace EntityMash.Database.Models
{
    public class DBEntity
    {
        [Key]
        public string Identifier { get; set; }
        public string ImageUrl { get; set; }
        public int Votes { get; set; }
    }
}
