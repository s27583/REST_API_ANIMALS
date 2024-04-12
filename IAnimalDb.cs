using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_ANIMALS
{
    public interface IAnimalDb
    {
        public ICollection<Animal> GetAnimals();
        public Animal GetById(int id);
        public void AddAnimal(Animal animal);
        public void UpdateAnimal(int id, Animal animal);
        public void DeleteAnimal(int id);
    }
}