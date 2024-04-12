using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_ANIMALS
{
    public class Animal
    {
        [Required]
        public int IdAnimal { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Mass { get; set; }
        [Required]
        public string FurColor { get; set; }        
    }
}