using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewery.BusinessLogicLayer;
using Brewery.DataAccessLayer;
using Brewery.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beer.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly BeerLogic _logic;
        public BeerController()
        {
            _logic = new BeerLogic(new EFGenericRepository<BeerPoco>());
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<BeerPoco>), 200)]
        public ActionResult GetAllApplicantEducation()
        {
            return Ok(_logic.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetBeer(Guid id)
        {
            BeerPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpPost]
        public ActionResult PostApplicantEducation([FromBody] BeerPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }
        [HttpPut]
        public ActionResult PutApplicantEducation([FromBody] BeerPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteApplicantEducation([FromBody] BeerPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
