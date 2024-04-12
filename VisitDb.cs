using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_ANIMALS
{
    public class VisitDb : IVisitDb
    {
        private ICollection<Visit> _visits;

        public VisitDb()
        {
            _visits = new List<Visit>
            {
                new Visit() { Id = 1, AnimalName = "Benny", VisitDate = new DateTime(2024, 4, 1), Description = "Vaccination", Price = 30},
                new Visit() { Id = 2, AnimalName = "Nick", VisitDate = new DateTime(2024, 3, 15), Description = "Checkup", Price = 40},
                new Visit() { Id = 3, AnimalName = "Oscar", VisitDate = new DateTime(2024, 3, 20), Description = "Injury", Price = 50},
                new Visit() { Id = 4, AnimalName = "Diego", VisitDate = new DateTime(2024, 4, 5), Description = "Checkup", Price = 35},
                new Visit() { Id = 5, AnimalName = "Wiener", VisitDate = new DateTime(2024, 4, 10), Description = "Feeding", Price = 90}
            };
        }

        public void AddVisit(Visit visit)
        {
            _visits.Add(visit);
        }

        public ICollection<Visit> GetVisits()
        {
            return _visits;
        }

        public Visit GetVisitById(int id)
        {
            return _visits.FirstOrDefault(v => v.Id == id);
        }
    }
}