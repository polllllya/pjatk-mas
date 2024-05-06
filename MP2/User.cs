namespace MP2;

public class User:Person
{
    private List<Recipe> _favoriteRecipes = new(); 
    public List<Recipe> CreatedRecipes = new(); 
    
    public User(string name, string surname, string login, string password) : base(name, surname, login, password)
    {
    }

    public void AddToFavorite(Recipe recipe)
    {
        _favoriteRecipes.Add(recipe);
        recipe.AddToUsersInLove(this);
    }
    
    public void CreateRecipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber)
    {
        var recipe = new Recipe(name, description, preparationTime, cookingTime, caloriesNumber, this);
    }
    
    
    public override string ToString()
    {
        var userInfo = base.ToString(); 
        var favoriteRecipesInfo = $"----- FAVORITE RECIPES -----\n";
        foreach (var recipe in _favoriteRecipes)
        {
            favoriteRecipesInfo += recipe + "\n";
        }

        var createdRecipesInfo = $"----- CREATED RECIPES -----\n";
        foreach (var recipe in CreatedRecipes)
        {
            createdRecipesInfo += recipe + "\n"; 
        }

        return userInfo + "\n" + favoriteRecipesInfo + "\n" + createdRecipesInfo + "\n";
    }
    
}