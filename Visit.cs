using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_ANIMALS
{
    public class Visit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string AnimalName { get; set; }
        [Required]
        public DateTime VisitDate { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}