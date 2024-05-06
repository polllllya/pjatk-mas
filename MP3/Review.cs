using System.Data;

namespace MP3;

public class Review
{
    private int Id { get; set; }
    private static int _counter; 
    public Person Reviewer { get; init; }
    public Recipe ReviewedRecipe { get; init; }
    public string Content { get; set; }
    public int Rating { get; set; }
    public DateOnly Date { get; set; }

    public DifficultyReview DifficultyReview { get; init; }

    public TasteReview TasteReview { get; init; }

    public Review(Person reviewer, string content, int rating, DateOnly date, DifficultyReview difficultyReview, TasteReview tasteReview)
    {
        DifficultyReview = difficultyReview ?? throw new NoNullAllowedException();
        TasteReview = tasteReview ?? throw new NoNullAllowedException();
        
        Id = ++_counter;
        Reviewer = reviewer;
        if (tasteReview.Recipe != null && tasteReview.Recipe == difficultyReview.Recipe)
            ReviewedRecipe = tasteReview.Recipe;
        else
            throw new ArgumentException();
        Content = content;
        Rating = rating;
        Date = date;
    }
    
    public Review(Person reviewer, Recipe recipe, string content, int rating, DateOnly date, int tasteRating, string taste, int difficultyRating, string difficulty)
    {
        DifficultyReview = new DifficultyReview(difficultyRating, difficulty, recipe);
        TasteReview = new TasteReview(tasteRating, taste, recipe);

        ReviewedRecipe = recipe;
        
        Id = ++_counter;
        Reviewer = reviewer;
        
        Content = content;
        Rating = rating;
        Date = date;
    }
    
    public override string ToString()
    {
        return $"Reviewer: {Reviewer.Name}, Recipe: {ReviewedRecipe.Name}, Content: {Content}, Rating: {Rating}, Date: {Date}";
    }
}