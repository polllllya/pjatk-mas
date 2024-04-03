namespace MP1;

public class User:Person
{
    public List<Recipe> FavoriteRecipes = new List<Recipe>();
    public List<Recipe> CreatedRecipes = new List<Recipe>();
    
    public User(string name, string surname, string login, string password) : base(name, surname, login, password)
    {
    }
}