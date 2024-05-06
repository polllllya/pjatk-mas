namespace MP3;

public class KetoRecipe:Recipe
{
    public static List<KetoRecipe> KetoRecipes = new List<KetoRecipe>();

    public static List<string> AllowedIngredients = new List<string>() {
        "Meat",
        "Fish",
        "Leafy Greens",
        "Eggs",
        "Cheese",
        "Nuts and Seeds",
        "Avocado",
        "Berries",
        "Oils"
    };

    public KetoRecipe(string name, string description, int preparationTime, int cookingTime, Dictionary<string, Ingredient> ingredients, int caloriesNumber, int fatNumber, int carbsNumber, int proteinNumber, User creator)
        : base(name, description, preparationTime, cookingTime, ingredients, caloriesNumber, fatNumber, carbsNumber, proteinNumber, creator)
    {
        foreach (var ingredient in ingredients.Keys)
        {
            if (!AllowedIngredients.Contains(ingredient))
            {
                throw new ArgumentException($"Ingredient {ingredient} is not allowed in the recipe ingredients.");
            }
        }
    }
    
    public KetoRecipe(Recipe recipe) :
        base(recipe.Name, recipe.Description, recipe.PreparationTime, recipe.CookingTime, recipe.Ingredients, recipe.CaloriesNumber, recipe.FatNumber, recipe.CarbsNumber, recipe.ProteinNumber, recipe.Creator)
    {
        foreach (var ingredient in recipe.Ingredients.Keys)
        {
            if (!AllowedIngredients.Contains(ingredient))
            {
                throw new ArgumentException($"Ingredient {ingredient} is not allowed in the recipe ingredients.");
            }
        }
    }
    
    public void AddNewIngredient(Ingredient newIngredient)
    {
            if (!AllowedIngredients.Contains(newIngredient.Name))
            {
                Ingredients.Add(newIngredient.Name,newIngredient);
                ConvertToLowCarbRecipe(Ingredients);
            }
            else
            {
                Ingredients.Add(newIngredient.Name,newIngredient);
            }
    }
    private void ConvertToLowCarbRecipe(Dictionary<string, Ingredient> ingredients)
    {
        var lowCarbRecipe = new LowCarbRecipe(this);
        LowCarbRecipe.LowCarbRecipes.Add(lowCarbRecipe);
        KetoRecipes.Remove(this);
    }
    
    public static void AddAllowedIngredient(string ingredient) {
        AllowedIngredients.Add(ingredient);
    }

    public static void RemoveAllowedIngredient(string ingredient) {
        AllowedIngredients.Remove(ingredient);
    }
}