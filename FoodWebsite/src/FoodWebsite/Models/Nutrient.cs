using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWebsite.Models
{
    // Nutrition
    public class Nutrient
    {
        [Display(Name = "Brennwert")]
        public float CaloricEnergy { get; set; }

        [Display(Name = "Fat")]
        public float Fat { get; set; }

        [Display(Name = "Kohlenhydrate")]
        public float Carbonhydrates { get; set; }

        [Display(Name = "Eiweiß")]
        public float Protein { get; set; }
    }
}
