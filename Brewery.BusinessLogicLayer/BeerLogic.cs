using Brewery.DataAccessLayer;
using Brewery.Pocos;
using System;
using System.Collections.Generic;


namespace Brewery.BusinessLogicLayer
{
    public class BeerLogic : BaseLogic<BeerPoco>
    {
        public BeerLogic(IDataRepository<BeerPoco> repository) : base(repository)
        {

        }
        public override void Add(BeerPoco[] pocos)
        {
            Verify(pocos);
            base.Add(pocos);
        }
        public override void Update(BeerPoco[] pocos)
        {
            Verify(pocos);
            base.Update(pocos);
        }
        protected override void Verify(BeerPoco[] pocos)
        {
            List<ValidationException> exceptions = new List<ValidationException>();
            foreach (BeerPoco poco in pocos)
            {
                if(poco.Name == null)
                {
                    exceptions.Add(new ValidationException(101, "Name field must specified!!"));
                }
                
            }
            if (exceptions.Count > 0) throw new AggregateException(exceptions);
        }
    }
}
