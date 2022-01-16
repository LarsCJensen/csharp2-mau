using System.ComponentModel.DataAnnotations;

namespace Assignment3.Reptiles
{
    /// <summary>
    /// Enums for reptiles
    /// </summary>
    public enum ReptileTypes
    {
        [Display(Name = "Snake")]
        Snake,
        [Display(Name = "Crocodile")]
        Crocodile,
    }
}
