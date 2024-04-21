using System.Text.Json;

namespace MP2;

public class Recipe
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int TotalTime => PreparationTime + CookingTime; 
    public int CaloriesNumber { get; set; }
    private bool IsApproved { get; set; }
    public static List<Recipe> Recipes = new(); 
    public List<User> UsersInLove { get; set; } = new List<User>();
    
    public List<Review> Reviews { get; set; } = new List<Review>();
    private Dictionary<string, Ingredient> _ingredients = new Dictionary<string, Ingredient>();

    public User Creator { get; set; }
    
    public Recipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber, User creator)
    {
        Name = name;
        Description = description;
        PreparationTime = preparationTime;
        CookingTime = cookingTime;
        CaloriesNumber = caloriesNumber;
        IsApproved = false;
        Creator = creator; 
        creator.CreatedRecipes.Add(this);
    }
    
    public void AddToUsersInLove(User user)
    {
        UsersInLove.Add(user);
    }
    
    public void AddReview(Review review)
    {
        if (Reviews.Any(r => r.Reviewer == review.Reviewer))
        {
            throw new InvalidOperationException("User has already reviewed this recipe.");
        }
        
        Reviews.Add(review);
    }
    
    public string ShowAllReviews()
    {
        var allReviews = $"Recipe: {Name}\n";
        foreach (var review in Reviews)
        {
            allReviews += review + "\n";
        }

        return allReviews;
    }
    
    public void AddIngredient(Ingredient ingredient)
    {
        if (_ingredients.ContainsKey(ingredient.Name))
            throw new ArgumentException("An ingredient with this name already exists in the recipe.");
        _ingredients.Add(ingredient.Name, ingredient);
    }

    public bool RemoveIngredient(string ingredientName)
    {
        return _ingredients.Remove(ingredientName);
    }

    public Ingredient GetIngredient(string ingredientName)
    {
        if (_ingredients.TryGetValue(ingredientName, out Ingredient ingredient))
        {
            return ingredient;
        }
        throw new KeyNotFoundException("Ingredient not found in the recipe.");
    }
    
    public void DisplayIngredients()
    {
        Console.WriteLine($"Ingredients for {Name}:");
        foreach (var ingredient in _ingredients.Values)
        {
            Console.WriteLine(ingredient);
        }
    }
    
    
    public void Verify(bool isApproved)
    {
        if (isApproved != IsApproved)
            IsApproved = isApproved; 
        
        Recipes.Add(this);
    }
    
    public static void RemoveRecipe(Recipe recipe) 
    {
        Recipes.Remove(recipe);
    }
    
    public static void RemoveRecipe(string name) 
    {
        var recipeToRemove = Recipes.Find(recipe => recipe.Name == name);
        
        if (recipeToRemove != null)
        {
            Recipes.Remove(recipeToRemove);
        } else
        {
            Console.WriteLine("Recipe with the provided name was not found");
        }
    }
    
    public static void Save(string fileName, List<Recipe> recipes) 
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        string jsonString = JsonSerializer.Serialize(recipes, options);
        File.WriteAllText(fileName, jsonString);
    }
    
    public static List<Recipe> Load(string fileName)
    {
        string jsonString = File.ReadAllText(fileName);
        if (jsonString == null)
        {
            throw new InvalidOperationException("The read JSON string is null.");
        }

        return JsonSerializer.Deserialize<List<Recipe>>(jsonString)!;
    }
    
    public void GetRecipe(string recipeName)
    {
        if (Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine($"Description: {Description}");
            Console.WriteLine($"Preparation Time: {PreparationTime} min");
            Console.WriteLine($"Cooking Time: {CookingTime} min");
            Console.WriteLine($"Total Time: {TotalTime} min");
            Console.WriteLine($"Calories Number: {CaloriesNumber} kcal");
            Console.WriteLine($"Is Approved: {IsApproved}");
            Console.WriteLine($"Creator: {Creator.Name} {Creator.Surname}");
            Console.WriteLine("Ingredients:");
            DisplayIngredients();
        }
        else
        {
            Console.WriteLine("Recipe not found.");
        }
    }
    
    public override string ToString()
    {
        var usersInLove = "";
        foreach (var user in UsersInLove)
        {
            usersInLove += "[ " + user.Name + " " + user.Surname + " ]";
        }
        return $"Name: {Name}\n" +
               $"Description: {Description}" + $"\n" +
               $"Preparation Time: {PreparationTime} min\n" +
               $"Cooking Time: {CookingTime} min\n" +
               $"Total Time: {TotalTime} min\n" +
               $"Calories Number: {CaloriesNumber} kcal\n" +
               $"Is Approved: {IsApproved}\n" +
               $"Users who like: {usersInLove}\n" +
               $"Creator: {Creator.Name} {Creator.Surname}\n";
    }

}