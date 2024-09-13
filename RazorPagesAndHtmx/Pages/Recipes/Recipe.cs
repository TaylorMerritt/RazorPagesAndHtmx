using System.ComponentModel.DataAnnotations;

namespace RazorPagesAndHtmx.Pages.Recipes;

public class Recipe
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; } = string.Empty;

    public List<Ingredient> Ingredients { get; set; } = [];
}

public class Ingredient
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
}