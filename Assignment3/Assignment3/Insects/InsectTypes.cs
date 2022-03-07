using System.ComponentModel.DataAnnotations;

namespace Assignment3.Insects
{
    /// <summary>
    /// Class for insect enums
    /// </summary>
    public enum InsectTypes
    {
        [Display(Name = "Butterfly")]
        Butterfly,
        [Display(Name = "Bee")]
        Bee,
    }
}
