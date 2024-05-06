using System.Data;

namespace MP3;

public class DifficultyReview
{
    public int DifficultyLevel { get; set; }
    public string DifficultyComment { get; set; }
    private Review? Review { get; set; }
    
    public Recipe Recipe { get; init; }

    public DifficultyReview(int difficultyLevel, string difficultyComment, Recipe recipe)
    {
        DifficultyLevel = difficultyLevel;
        DifficultyComment = difficultyComment;
        Recipe = recipe ?? throw new NoNullAllowedException();
    }

    public DifficultyReview(Review? review, int difficultyLevel, string difficultyComment,Recipe recipe)
    {
        Review = review ?? throw new NoNullAllowedException("Review can't be null.");
        Recipe = recipe ?? throw new NoNullAllowedException();
        DifficultyLevel = difficultyLevel;
        DifficultyComment = difficultyComment;
    }

    public override string ToString()
    {
        return $"{Recipe} - {DifficultyLevel}";
    }
}