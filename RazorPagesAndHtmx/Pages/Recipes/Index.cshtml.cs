using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesAndHtmx.Pages.Recipes;

public class Index : PageModel
{
    public List<Recipe> Recipes { get; set; } = RecipeStore.GetAll().GetAwaiter().GetResult();
    public void OnGet()
    {
        
    }
}