namespace MP3;

public class LowCarbRecipe:Recipe
{
    public static int MaxCarbsNumber = 30;
    public static List<LowCarbRecipe> LowCarbRecipes = new List<LowCarbRecipe>();


    public LowCarbRecipe(string name, string description, int preparationTime, int cookingTime,Dictionary<string, Ingredient> ingredients, int caloriesNumber, int fatNumber, int carbsNumber, int proteinNumber, User creator) : base(name, description, preparationTime, cookingTime, ingredients, caloriesNumber, fatNumber, carbsNumber, proteinNumber, creator)
    {
        if (carbsNumber > MaxCarbsNumber)
        {
            throw new ArgumentException("Carb number cannot exceed max carb number.");
        }
    }
    
    public LowCarbRecipe(Recipe recipe) :
        base(recipe.Name, recipe.Description, recipe.PreparationTime, recipe.CookingTime, recipe.Ingredients, recipe.CaloriesNumber, recipe.FatNumber, recipe.CarbsNumber, recipe.ProteinNumber, recipe.Creator)
    {
        if (recipe.CarbsNumber > MaxCarbsNumber)
        {
            throw new ArgumentException("Carb number cannot exceed max carb number.");
        }
    }
}

