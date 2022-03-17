using System.ComponentModel.DataAnnotations;

namespace Assignment4.Mammals
{
    /// <summary>
    /// Enums for mammals
    /// </summary>
    public enum MammalTypes
    {
        [Display(Name = "Cat")]
        Cat,
        [Display(Name = "Dog")]
        Dog,
        [Display(Name = "Elephant")]
        Elephant,
        [Display(Name = "Horse")]
        Horse
    }
}
