using System.Data;

namespace MP3;

public class Admin:Person
{
    
    public Admin(string name, string login, string password) : base(name, login, password)
    {
    }

    public Admin(string name, string surname, string login, string password) : base(name, surname, login, password)
    {
    }

    public override void DeleteReview(Review review, Recipe recipe)
    {
        var reviewToRemove = recipe.Reviews.Find(r => r == review);
        
        if (reviewToRemove != null)
        {
            recipe.Reviews.Remove(reviewToRemove);
            Console.WriteLine("The review has been deleted\n");
        }
        else
        {
            Console.WriteLine("Review was not found\n");
        }
    }
    
    public override void DeleteRecipe(Recipe recipe)
    {
        var recipeToRemove = Recipe.Recipes.Find(r => r == recipe);
        if (recipeToRemove != null)
        {
            Recipe.Recipes.Remove(recipe);
            Console.WriteLine("The recipe has been deleted\n");
        }
        else
        {
            Console.WriteLine("Recipe was not found\n");
        }
    }
}