using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RazorPagesAndHtmx.Extensions;

public static class ModelStateExtensions
{
    public static void ClearAndPreserveErrors(this ModelStateDictionary modelState)
    {
        // Capture the existing errors
        var errorEntries = modelState
            .Where(entry => entry.Value is { Errors.Count: > 0 })
            .ToList();

        // Clear the ModelState
        modelState.Clear();

        // Re-add the errors to the ModelState
        foreach (var entry in errorEntries)
        {
            if (entry.Value?.Errors is null)
            {
                continue;
            }
            
            foreach (var error in entry.Value.Errors)
            {
                modelState.AddModelError(entry.Key, error.ErrorMessage);
            }
        }
    }
}