using MP3;

var admin1 = new Admin("Pola", "Brahina", "polllya", "pooolaaa");
var user1 = new User("Anton", "Reut", "a.black", "987654321A");
var user2 = new User("Jan", "Kowalski", "jankow", "jan111");

var ingredients = new Dictionary<string, Ingredient>();
ingredients.Add("Flour",new Ingredient("Flour", 2, "cups"));
ingredients.Add("Sugar",new Ingredient("Sugar", 1,"cup"));
ingredients.Add("Cocoa Powder",new Ingredient("Cocoa Powder", 0.5,"cup"));
ingredients.Add("Baking Powder",new Ingredient("Baking Powder", 2, "tsp"));

var ingredients1 = new Dictionary<string, Ingredient>();
ingredients1.Add("Meat",new Ingredient("Meat", 2, "piece"));

var recipe1 = new Recipe("Chocolate Cake", "Delicious and rich chocolate cake", 10, 20, ingredients,300, 20, 8, 18,user1);
var recipe2 = new Recipe("Omelette", "Classic omelette recipe", 5, 10, ingredients,200, 20, 8, 18,user1);
var recipe3 = new Recipe("Spaghetti Bolognese", "Classic Italian spaghetti with meat sauce", 15, 30, ingredients,400, 20, 8, 18,user2);
var recipe4 = new Recipe("Chicken Curry", "Authentic Indian chicken curry", 20, 40, ingredients, 350, 20, 8, 18,user2);

//---------------------------------- Klasa abstrakcyjna i polimorficzne wołanie metod ----------------------------------
//
// var review1 = new Review(user1, recipe1, "This is a very good recipe", 5, new DateOnly(2024, 08, 10),5, "Good", 4, "Noot bad");
// recipe1.AddReview(review1);
//
// var review2 = new Review(user2, recipe1, "I like it!", 5, new DateOnly(2024, 07, 24), 8, "Tasty", 9, "VVery hard");
// recipe1.AddReview(review2);
//
// Console.WriteLine(recipe1.ShowAllReviews());
//
// user1.DeleteReview(review2,recipe1);
// admin1.DeleteReview(review1,recipe1);
// user2.DeleteReview(review2,recipe1);
//
// Console.WriteLine(recipe1.ShowAllReviews());

//---------------------------------------------------- Overlapping -----------------------------------------------------

var childrenRecipe = new ChildrenRecipe(5, 10, "Fun presentation ideas for kids", recipe1);
var holidayRecipe = new HolidayRecipe("Christmas", null, recipe1);

// Console.WriteLine($"Recipe Name: {recipe1.Name}");
// Console.WriteLine($"Holiday Type: {recipe1.HolidayRecipe?.HolidayType}");
// Console.WriteLine($"Max age of the child: {recipe1.ChildrenRecipe?.MaxAge}");
// Console.WriteLine($"Min age of the child: {recipe1.ChildrenRecipe?.MinAge}");

//----------------------------------------------------- Dynamiczne -----------------------------------------------------

var ketoRecipe = new KetoRecipe("Chicken", "Delicious keto chicken recipe", 30, 60, ingredients1, 500, 30, 5, 50, user1);
var lowCarbRecipe = new LowCarbRecipe("Broccoli", "Healthy low carb broccoli recipe", 20, 40, ingredients, 300, 20, 15, 25, user1);
    
// KetoRecipe.KetoRecipes.Add(ketoRecipe);
// LowCarbRecipe.LowCarbRecipes.Add(lowCarbRecipe);
//
// Console.WriteLine("KETO RECIPES:");
// foreach (var recipe in KetoRecipe.KetoRecipes)
// {
//     Console.WriteLine(recipe);
// }
//
// Console.WriteLine("LOW CARB RECIPES:");
// foreach (var recipe in LowCarbRecipe.LowCarbRecipes)
// {
//     Console.WriteLine(recipe);
// }
//
// var newIngredient = new Ingredient("Bread", 100, "g");
// ketoRecipe.AddNewIngredient(newIngredient);
//
// Console.WriteLine("KETO RECIPES:");
// foreach (var recipe in KetoRecipe.KetoRecipes)
// {
//     Console.WriteLine(recipe);
// }
//
// Console.WriteLine("LOW CARB RECIPES:");
// foreach (var recipe in LowCarbRecipe.LowCarbRecipes)
// {
//     Console.WriteLine(recipe);
// }

//--------------------------------------------------- Wieloaspektowe ---------------------------------------------------

var lowCarbRecipe1 = new LowCarbRecipe("Broccoli", "Healthy low carb broccoli recipe", 20, 40, ingredients, 300, 20, 15, 25, user1);
var childrenRecipe1 = new ChildrenRecipe(5, 10, "Fun presentation ideas for kids", lowCarbRecipe1);
//
// Console.WriteLine("Children Recipe = LowCarb Recipe: Name - "+childrenRecipe1.Recipe.Name);

//------------------------------------------------- Wielodzidziczenie --------------------------------------------------
// Console.WriteLine();
// var difReview = new DifficultyReview(2, "Easy to make, needs a little effort", lowCarbRecipe1);
// Console.WriteLine(difReview);
// Console.WriteLine();
// var tasteReview = new TasteReview(7,"Very tasty, but i wanted more sugar", lowCarbRecipe1);
// Console.WriteLine(tasteReview);
// Console.WriteLine();
//
// var review = new Review(user1, "This is a very good recipe", 5, new DateOnly(2024, 08, 10), difReview, tasteReview);
// Console.WriteLine(review);