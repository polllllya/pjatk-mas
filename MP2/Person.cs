namespace MP2;
public abstract class Person
{
    public string Name { get; set; }
    public string? Surname { get; set; }
    private string Login { get; set; }
    private string Password { get; set; }
    
    public static int TotalPersonCount { get; set; }
    
    public static List<Person> People = new();

    protected Person(string name, string login, string password)
    {
        People.Add(this);

        Name = name;
        Surname = null;
        Login = login;
        Password = password;

        TotalPersonCount++;
    }
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
    
    
    public override string ToString()
    {
        return $"\t{Name} {Surname}";
    }
}