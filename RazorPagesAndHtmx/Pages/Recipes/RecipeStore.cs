namespace RazorPagesAndHtmx.Pages.Recipes;

public static class RecipeStore
{
    private static readonly List<Recipe> Recipes =
    [
        new() { Description = "Test 1", Name = "Test Name 1", Ingredients = [new Ingredient { Name = "1" }] },
    ];
    
    public static async Task<List<Recipe>> GetAll()
    {
        await Task.Delay(1000);
        return Recipes;
    }
    
    public static async Task Add(Recipe recipe)
    {
        await Task.Delay(1000);
        Recipes.Add(recipe);
    }
    
    public static void Remove(Recipe recipe)
    {
        Recipes.Remove(recipe);
    }
}