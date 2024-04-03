namespace MP1;

public abstract class Person
{
    private static int counter;
    public int Id { get; }
    public string Name { get; private set; }
    public string Surname { get; private set; }

    
    public static List<Person> People = new();
    private string Login { get; set; }
    private string Password { get; set; }
    

    protected Person(string name, string surname, string login, string password)
    {
        Id = ++counter;

        People.Add(this);

        Name = name;
        Surname = surname;
        Login = login;
        Password = password;
    }
}