using System.Data;

namespace MP3;

public class HolidayRecipe 
{
    public string HolidayType { get; set; }
    public List<Recipe>? RecommendedRecipes { get; set; }
    private Recipe Recipe { get; init; }

    public HolidayRecipe(string holidayType, List<Recipe>? recommendedRecipes, Recipe recipe)
    {
        Recipe = recipe ?? throw new NoNullAllowedException();
        if (Recipe.HolidayRecipe != null) {
                throw new ArgumentException($"Recipe {Recipe.Name} already has HolidayRecipe");
        }
        HolidayType = holidayType; 
        RecommendedRecipes = recommendedRecipes;
        Recipe.HolidayRecipe = this; 
    }

    public HolidayRecipe(string holidayType, Recipe recipe)
    {
        Recipe = recipe ?? throw new NoNullAllowedException();
        if (Recipe.HolidayRecipe != null) 
        { 
            throw new ArgumentException($"Recipe {Recipe.Name} already has HolidayRecipe"); 
        } 
        HolidayType = holidayType; 
        Recipe.HolidayRecipe = this; 
    }
}