using System.Data;

namespace MP3;

public class TasteReview
{
    public int TasteLevel { get; set; }
    public string TasteComment { get; set; }
    public Recipe Recipe { get; set; }
    private Review? Review { get; init; }

    public TasteReview(int tasteLevel, string tasteComment, Recipe recipe)
    {
        TasteLevel = tasteLevel;
        TasteComment = tasteComment;
        Recipe = recipe ?? throw new NoNullAllowedException();
    }
    
    public TasteReview(int tasteLevel, string tasteComment, Recipe recipe, Review review)
    {
        TasteLevel = tasteLevel;
        TasteComment = tasteComment;
        Recipe = recipe ?? throw new NoNullAllowedException();
        Review = review ?? throw new NoNullAllowedException();
    }
    
    public override string ToString()
    {
        return $"{Recipe} - {TasteLevel}";
    }
}