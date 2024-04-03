namespace MP1;

public class Recipe
{
    private static int counter;
    public int Id { get; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PreparationTime { get; set; }
    public int CaloriesNumber { get; set; }
    private bool IsApproved { get; set; }
    public static List<Recipe> Recipes = new();
    
    public static int NumberOfApproved  
    {
        get
        {
            int number = 0;
            foreach (var recipe in Recipes)
            {
                if (recipe.IsApproved)
                    number++;
            }
            return number;
        }
    }

    public Recipe(string name, string description, int preparationTime, int caloriesNumber)
    {
        Id = ++counter;
        Name = name;
        Description = description;
        PreparationTime = preparationTime;
        CaloriesNumber = caloriesNumber;
        IsApproved = false;
    }

    private void Approve()
    { 
        IsApproved = true;
    }
    
    private void NotApprove()
    { 
        IsApproved = false;
    }
}