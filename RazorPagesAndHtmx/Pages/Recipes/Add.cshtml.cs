using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesAndHtmx.Extensions;

namespace RazorPagesAndHtmx.Pages.Recipes;

public class Add : PageModel
{
    [BindProperty]
    public Recipe NewRecipe { get; set; } = new();

    public void OnGet()
    {
        if (NewRecipe.Ingredients.Count == 0)
        {
            NewRecipe.Ingredients.Add(new Ingredient());
        }
    }

    public IActionResult OnPostAddIngredient()
    {
        NewRecipe.Ingredients.Add(new Ingredient());
        ModelState.ClearAndPreserveErrors();
        return Page();
    }

    public IActionResult OnPostRemoveIngredient(int index)
    {
        if (index >= 0 && index < NewRecipe.Ingredients.Count)
        {
            NewRecipe.Ingredients.RemoveAt(index);
        }

        if (NewRecipe.Ingredients.Count == 0)
        {
            NewRecipe.Ingredients.Add(new Ingredient());
        }
        
        ModelState.ClearAndPreserveErrors();
        return Page();
    }

    public async Task<IActionResult> OnPostAddRecipe()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (NewRecipe.Ingredients.Count == 0)
        {
            ModelState.AddModelError("Ingredients", "At least one ingredient is required.");
            return Page();
        }

        await RecipeStore.Add(NewRecipe);
        return RedirectToPage("./Index");
    }
}