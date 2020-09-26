using System;
using System.Collections.Generic;
using System.Text;

namespace Brewery.Pocos
{
    public class BeerPoco : IPoco
    {
        public Guid Id { get; set; }

        public Guid BrweryId { get; set; }
        public virtual BreweryPoco Brewery { get; set; }

        public string Name { get; set; }
        public string Style { get; set; }
        public long Upc { get; set; }

    }
}
