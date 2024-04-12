using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace REST_API_ANIMALS
{
    [ApiController]
    [Route("canimals")]
    public class AnimalsController : ControllerBase
    {

        private IAnimalDb _animalDb;

        public AnimalsController(IAnimalDb animalDb)
        {
            _animalDb = animalDb;
        }

        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(_animalDb.GetAnimals());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animal = _animalDb.GetById(id);
            if (animal is null) return NotFound();

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            _animalDb.AddAnimal(animal);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Animal animal)
        {
            var existingAnimal = _animalDb.GetById(id);
            if (existingAnimal == null) return NotFound();

            _animalDb.UpdateAnimal(id, animal);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _animalDb.DeleteAnimal(id);
            return NoContent();

        }
    }
}