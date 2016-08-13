using System.ComponentModel.DataAnnotations;

namespace OdeToFood_DotNetCore.Entities
{
    public enum CuisineType
    {
        None,
        Italian,
        French,
        American
    }

    public class Restaurant
    {
        public int Id { get; set; }

        //[Required,Display(Name ="Restaurant name"),MaxLength(20)]
        public string Name { get; set; }

        //[Required]
        public CuisineType Cuisine { get; set; }
    }
}
