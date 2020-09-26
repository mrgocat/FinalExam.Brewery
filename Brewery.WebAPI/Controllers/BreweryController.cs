using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewery.BusinessLogicLayer;
using Brewery.DataAccessLayer;
using Brewery.Pocos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Brewery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private readonly BreweryLogic _logic;
        public BreweryController()
        {
            _logic = new BreweryLogic(new EFGenericRepository<BreweryPoco>());
        }
        [HttpGet]
        [ProducesResponseType(typeof(List<BreweryPoco>), 200)]
        public ActionResult GetAllApplicantEducation()
        {
            return Ok(_logic.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetBrewery(Guid id)
        {
            BreweryPoco poco = _logic.Get(id);
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
        public ActionResult PostApplicantEducation([FromBody] BreweryPoco[] pocos)
        {
            _logic.Add(pocos);
            return Ok();
        }
        [HttpPut]
        public ActionResult PutApplicantEducation([FromBody] BreweryPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }
        [HttpDelete]
        public ActionResult DeleteApplicantEducation([FromBody] BreweryPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }
    }
}
