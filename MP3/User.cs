using System.Data;

namespace MP3;

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
    
    public void CreateRecipe(string name, string description, int preparationTime, int cookingTime, Dictionary<string, Ingredient> ingredients, int caloriesNumber, int fatNumber,  int carbsNumber, int proteinNumber)
    {
        var recipe = new Recipe(name, description, preparationTime, cookingTime, ingredients, caloriesNumber, fatNumber, carbsNumber,proteinNumber,this);
    }
    
    
    public override void DeleteReview(Review review, Recipe recipe)
    {
            var reviewToRemove = recipe.Reviews.Find(r => r == review);

            if (reviewToRemove != null)
            {
                if (review.Reviewer == this)
                {
                    recipe.Reviews.Remove(reviewToRemove);
                    Console.WriteLine("The review has been deleted\n");
                }
                else
                {
                    Console.WriteLine("You can't delete reviews that aren't yours\n");
                }
                
            }
            else
            {
                Console.WriteLine("Recipe with the provided name was not found\n");
            }
    }
        
    

    public override void DeleteRecipe(Recipe recipe)
    {
        var recipeToRemove = Recipe.Recipes.Find(r => r == recipe);
        if (recipeToRemove != null)
        {
            if (recipe.Creator == this)
            {
                Recipe.Recipes.Remove(recipe);
            }
            else
            {
                Console.WriteLine("You can't delete recipe that aren't yours\n");
            }
        }
        else
        {
            Console.WriteLine("Recipe was not found\n");
        }
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