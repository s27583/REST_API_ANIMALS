using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_ANIMALS
{
    public class AnimalDb : IAnimalDb
    {
        private ICollection<Animal> _animals;

        public AnimalDb()
        {
            _animals = new List<Animal>
            {
                new Animal(){ IdAnimal = 1, Name = "Arnold", Category = "Dog", Mass = 10.5, FurColor = "Brown" },
                new Animal(){ IdAnimal = 2, Name = "Rudy", Category = "Cat", Mass = 5.2, FurColor = "Orange" },
                new Animal(){ IdAnimal = 3, Name = "Remi", Category = "Rat", Mass = 0.3, FurColor = "White" },
                new Animal(){ IdAnimal = 4, Name = "Hamster", Category = "Mouse", Mass = 0.2, FurColor = "Gray" },
                new Animal(){ IdAnimal = 5, Name = "Beast", Category = "Snake", Mass = 3.8, FurColor = "Green" },
                new Animal(){ IdAnimal = 6, Name = "Pullup", Category = "Capybara", Mass = 20.2, FurColor = "Brown" },
                new Animal(){ IdAnimal = 7, Name = "Frogshop", Category = "Frog", Mass = 0.3, FurColor = "Green" }
            };
        }

        public void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }

        public void DeleteAnimal(int id)
        {
            var animalToDelete = _animals.FirstOrDefault(animal => animal.IdAnimal == id);

            if (animalToDelete != null)
            {
                _animals.Remove(animalToDelete);
            }
            else
            {
                throw new ArgumentException("Animal not found", nameof(id));
            }
        }

        public ICollection<Animal> GetAnimals()
        {
            return _animals;
        }

        public Animal? GetById(int id)
        {
            return _animals.FirstOrDefault(animal => animal.IdAnimal == id);
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            var oldAnimal = _animals.FirstOrDefault(a => a.IdAnimal == id);
            if (oldAnimal != null)
            {
                oldAnimal.Name = animal.Name;
                oldAnimal.Category = animal.Category;
                oldAnimal.Mass = animal.Mass;
                oldAnimal.FurColor = animal.FurColor;
            }
            else
            {
                throw new ArgumentException("Animal not found", nameof(oldAnimal.IdAnimal));
            }
        }
    }
}