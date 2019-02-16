using System;

namespace EntityMash.Models
{
    public class Entity
    {
        public Entity(string identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; }
        public Uri ImageUrl { get; set; }
        public int Votes { get; set; }
    }
}
