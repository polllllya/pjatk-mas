using System.Text.Json;

namespace MP1;

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
    
    public Recipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber)
    {
        Name = name;
        Description = description;
        PreparationTime = preparationTime;
        CookingTime = cookingTime;
        CaloriesNumber = caloriesNumber;
        IsApproved = false;
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
    
    
    public override string ToString()
    {
        return $"Name: {Name}\n" +
               $"Description: {Description}" + $"\n" +
               $"Preparation Time: {PreparationTime} min\n" +
               $"Cooking Time: {CookingTime} min\n" +
               $"Total Time: {TotalTime} min\n" +
               $"Calories Number: {CaloriesNumber} kcal\n" +
               $"Is Approved: {IsApproved}\n";
    }

}