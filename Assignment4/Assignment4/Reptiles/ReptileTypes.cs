using System.ComponentModel.DataAnnotations;

namespace Assignment4.Reptiles
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
