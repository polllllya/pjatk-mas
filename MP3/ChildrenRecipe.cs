using System.Data;

namespace MP3;

public class ChildrenRecipe
{
    public int MaxAge { get; set; }
    public int MinAge { get; set; }
    public string PresentationIdeas { get; set; }
    public Recipe Recipe { get; init; }

    public ChildrenRecipe(int maxAge, int minAge, string presentationIdeas, Recipe recipe)
    {
        Recipe = recipe ?? throw new NoNullAllowedException();
        if (Recipe.ChildrenRecipe != null) {
            throw new ArgumentException($"Recipe already has ChildrenRecipe");
        }
        MaxAge = maxAge;
        MinAge = minAge;
        PresentationIdeas = presentationIdeas;
        Recipe.ChildrenRecipe = this;
    }
}