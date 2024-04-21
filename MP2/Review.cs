namespace MP2;

public class Review
{
    public Person Reviewer { get; set; }
    public Recipe ReviewedRecipe { get; set; }
    public string Content { get; set; }
    public int Rating { get; set; }
    
    public DateOnly Date { get; set; }

    public Review(Person reviewer, Recipe reviewedRecipe, string content, int rating, DateOnly date)
    {
        Reviewer = reviewer;
        ReviewedRecipe = reviewedRecipe;
        Content = content;
        Rating = rating;
        Date = date;
    }
    
    public override string ToString()
    {
        return $"Reviewer: {Reviewer.Name} {Reviewer.Surname}, Recipe: {ReviewedRecipe.Name}, Content: {Content}, Rating: {Rating}, Date: {Date}";
    }
}