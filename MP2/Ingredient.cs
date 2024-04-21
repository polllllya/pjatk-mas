namespace MP2;

public class Ingredient
{
    public string Name { get; private set; }
    public double Quantity { get; private set; }  
    public string Measure { get; private set; }  

    public Ingredient(string name, double quantity, string measure)
    {
        Name = name;
        Quantity = quantity;
        Measure = measure;
    }

    public override string ToString()
    {
        return $"* {Name} - {Quantity} {Measure}";
    }
}