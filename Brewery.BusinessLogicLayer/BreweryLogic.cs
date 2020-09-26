using Brewery.DataAccessLayer;
using Brewery.Pocos;
using System;
using System.Collections.Generic;


namespace Brewery.BusinessLogicLayer
{
    public class BreweryLogic : BaseLogic<BreweryPoco>
    {
        public BreweryLogic(IDataRepository<BreweryPoco> repository) : base(repository)
        {

        }
        public override void Add(BreweryPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(BreweryPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(BreweryPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (BreweryPoco poco in pocos)
            {
                if(poco.Name == null)
                {
                    exceptions.Add(new ValidationException(201, "Name field must specified!!"));
                }
                
            }
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
}

