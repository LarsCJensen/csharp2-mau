using System.ComponentModel.DataAnnotations;

namespace Assignment3.Birds
{
    /// <summary>
    /// Enumgs or Birds
    /// </summary>
    public enum BirdTypes
    {
        [Display(Name = "Swallow")]
        Swallow,
        [Display(Name = "Blackbird")]
        Blackbird
    }
}
