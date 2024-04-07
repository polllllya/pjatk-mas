namespace MP1;

public class User:Person
{
    public List<Recipe> FavoriteRecipes = new(); 
    public List<Recipe> CreatedRecipes = new(); 
    
    public User(string name, string surname, string login, string password) : base(name, surname, login, password)
    {
    }

    public void AddToFavorite(Recipe recipe)
    {
        FavoriteRecipes.Add(recipe);
    }
    
    public override Recipe CreateRecipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber)
    {
        var recipe = base.CreateRecipe(name, description, preparationTime, cookingTime, caloriesNumber);
        CreatedRecipes.Add(recipe);

        return recipe;
    }
    
    
    public override string ToString()
    {
        var userInfo = base.ToString(); 
        var favoriteRecipesInfo = $"Favorite recipes:\n";
        foreach (var recipe in FavoriteRecipes)
        {
            favoriteRecipesInfo += recipe + "\n";
        }

        var createdRecipesInfo = $"Created recipes:\n";
        foreach (var recipe in CreatedRecipes)
        {
            createdRecipesInfo += recipe + "\n"; 
        }

        return "User " + userInfo + "\n" + favoriteRecipesInfo + "\n" + createdRecipesInfo + "\n";
    }
    
}