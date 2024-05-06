using MP2;

var user1 = new User("Pola", "Brahina", "polllly", "12345678P");
var user2 = new User("Anton", "Reut", "a.black", "987654321A");
var user3 = new User("Jan", "Kowalski", "jankow", "jan111");

var recipe1 = new Recipe("Chocolate Cake", "Delicious and rich chocolate cake", 10, 20, 300, user1);
var recipe2 = new Recipe("Omelette", "Classic omelette recipe", 5, 10, 200, user1);
var recipe3 = new Recipe("Spaghetti Bolognese", "Classic Italian spaghetti with meat sauce", 15, 30, 400, user2);
var recipe4 = new Recipe("Chicken Curry", "Authentic Indian chicken curry", 20, 40, 350, user2);

user3.AddToFavorite(recipe1);
user3.AddToFavorite(recipe3);
user2.AddToFavorite(recipe1);

// 1. Zwykła
// Console.WriteLine(user3);
// Console.WriteLine(recipe1); 

var review1 = new Review(user3, recipe1, "This is a very good recipe", 5, new DateOnly(2024, 08, 10));
recipe1.AddReview(review1);

var review2 = new Review(user2, recipe1, "I like it!", 5, new DateOnly(2024, 07, 24));
recipe1.AddReview(review2);

// 2. Z atrybutem
// Console.WriteLine(recipe1.ShowAllReviews());

recipe1.AddIngredient(new Ingredient("Flour", 2, "cups"));
recipe1.AddIngredient(new Ingredient("Sugar", 1,"cup"));
recipe1.AddIngredient(new Ingredient("Cocoa Powder", 0.5,"cup"));
recipe1.AddIngredient(new Ingredient("Baking Powder", 2, "tsp"));

// 3. Kwalifikowana
// recipe1.DisplayIngredients();
// Console.WriteLine("\n"+recipe1.GetIngredient("Sugar") + "\n");
// recipe1.RemoveIngredient("Sugar");
// recipe1.DisplayIngredients();

user2.CreateRecipe("Chocolate Cake", "Delicious and rich chocolate cake", 10, 20, 300);

// // 4. Kompozycja
// foreach (var recipe in user2.CreatedRecipes)
// {
//     Console.WriteLine(recipe);
// }