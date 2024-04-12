using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace REST_API_ANIMALS
{
    [ApiController]
    [Route("cvisits")]
    public class VisitsController : ControllerBase
    {
        private readonly IVisitDb _visitDb;

        public VisitsController(IVisitDb visitDb)
        {
            _visitDb = visitDb;
        }

        [HttpGet]
        public IActionResult GetVisits()
        {
            return Ok(_visitDb.GetVisits());
        }

        [HttpGet("{id}")]
        public IActionResult GetVisitById(int id)
        {
            var visit = _visitDb.GetVisitById(id);
            if (visit == null)
                return NotFound();

            return Ok(visit);
        }

        [HttpPost]
        public IActionResult AddVisit(Visit visit)
        {
            _visitDb.AddVisit(visit);
            return Created();
        }
    }
}