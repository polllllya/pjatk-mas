namespace MP1;
public abstract class Person
{
    public string Name { get; set; }
    public string? Surname { get; set; }
    private string Login { get; set; }
    private string Password { get; set; }
    
    public static int TotalPersonCount { get; set; }
    
    public static List<Person> People = new();

    
    protected Person(string name, string surname, string login, string password)
    {
        People.Add(this);

        Name = name;
        Surname = surname;
        Login = login;
        Password = password;

        TotalPersonCount++;
    }
    
    public static void RemovePerson(Person person)
    {
        People.Remove(person);
    }

    public virtual Recipe CreateRecipe(string name, string description, int preparationTime, int cookingTime, int caloriesNumber)
    {
        var recipe = new Recipe(name, description, preparationTime, cookingTime,caloriesNumber);
        return recipe;
    }
    
    public override string ToString()
    {
        return $"{Name} {Surname}";
    }
}