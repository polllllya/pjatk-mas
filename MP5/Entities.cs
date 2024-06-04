namespace MP5;

public abstract class Person
{
    public string Name { get; set; }
    public string? Surname { get; set; }

    protected Person(string name, string? surname = null)
    {
        Name = name;
        Surname = surname;
    }
}

public class User : Person
{
    public int Id { get; set; }
    public List<Recipe> FavoriteRecipes { get; } = new List<Recipe>();
    public List<Recipe> CreatedRecipes { get; } = new List<Recipe>();

    public User(string name, string surname) : base(name, surname)
    {
    }

    public void AddToFavorite(Recipe recipe)
    {
        FavoriteRecipes.Add(recipe);
    }

    public Recipe CreateRecipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber)
    {
        var recipe = new Recipe(name, description, preparationTime, cookingTime, caloriesNumber)
        {
            Creator = this
        };
        CreatedRecipes.Add(recipe);
        return recipe;
    }
}

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int PreparationTime { get; set; }
    public int CookingTime { get; set; }
    public int TotalTime => PreparationTime + CookingTime;
    public int CaloriesNumber { get; set; }

    public int? CreatorId { get; set; }
    public User Creator { get; set; }

    public List<User> FavoritedByUsers { get; set; } = new List<User>();

    public Recipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber)
    {
        Name = name;
        Description = description;
        PreparationTime = preparationTime;
        CookingTime = cookingTime;
        CaloriesNumber = caloriesNumber;
    }
}

public class ChildrenRecipe : Recipe
{
    public int MaxAge { get; set; }
    public int MinAge { get; set; }
    public string PresentationIdeas { get; set; }

    public ChildrenRecipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber,
        int maxAge, int minAge, string presentationIdeas) 
        : base(name, description, preparationTime, cookingTime, caloriesNumber)
    {
        MaxAge = maxAge;
        MinAge = minAge;
        PresentationIdeas = presentationIdeas;
    }
}