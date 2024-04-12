using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_ANIMALS
{
    public interface IVisitDb
    {
        ICollection<Visit> GetVisits();
        Visit GetVisitById(int id);
        void AddVisit(Visit visit);
    }
}