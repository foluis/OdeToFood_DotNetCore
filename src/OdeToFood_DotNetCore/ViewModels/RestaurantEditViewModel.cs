using OdeToFood_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood_DotNetCore.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required(ErrorMessage ="{0} is very required"), 
            Display(Name = "Restaurant name"), 
            MaxLength(10,ErrorMessage = "{0} max length is {1}")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Select a value")]
        [Display(Description ="Cousine Type")]
        public CuisineType Cuisine { get; set; }
    }
}
