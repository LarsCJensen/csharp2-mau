namespace Assignment2.Animals
{
    /// <summary>
    /// Interface for animal
    /// </summary>
    interface IAnimal
    {
        string Id { get; set; }
        string Name { get; set; }
        int Age { get; set; }
        GenderType Gender { get; set; }
        AnimalCategoryEnum Category { get; set; }
        string Description { get; set; }
        string GetExtraInfo();
    }
}
