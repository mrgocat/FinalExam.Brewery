using System;
using System.Collections.Generic;

namespace Brewery.Pocos
{
    public class BreweryPoco : IPoco
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        
        public virtual ICollection<BeerPoco> Beers { get; set; }
    }
}
