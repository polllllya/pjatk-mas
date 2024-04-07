using MP1;


Console.WriteLine("----------- Testing Recipe class ------------\n");
Console.WriteLine("-creating recipes-\n");
var recipe1 = new Recipe("Pancakes", "Delicious pancakes recipe", 10, 20, 300);
var recipe2 = new Recipe("Omelette", "Classic omelette recipe", 5, 10, 200);
var recipe3 = new Recipe("Spaghetti Bolognese", "Classic Italian spaghetti with meat sauce", 15, 30, 400);
var recipe4 = new Recipe("Chicken Curry", "Authentic Indian chicken curry", 20, 40, 350);

Console.WriteLine("-verification for these recipes-\n");
recipe1.Verify(true);
recipe2.Verify(false);
recipe3.Verify(true);
recipe4.Verify(false);


Console.WriteLine("-show the list of recipes-\n");
foreach (var recipe in Recipe.Recipes)
{
    Console.WriteLine(recipe);
}

Console.WriteLine("-deleting recipe1 and recipe2 from the list-\n");
Recipe.RemoveRecipe("Pancakes");
Recipe.RemoveRecipe(recipe2);

Console.WriteLine("-show the list of recipes-\n");
foreach (var recipe in Recipe.Recipes)
{
    Console.WriteLine(recipe);
}

Console.WriteLine("------ Testing Person and User classes ------\n");
Console.WriteLine("-creating users-\n");
var user1 = new User("Pola", "Brahina", "polllly", "12345678P");
var user2 = new User("Anton", "Reut", "a.black", "987654321A");
var user3 = new User("Test", "Test", "test", "test");

foreach (var person in Person.People)
{
    Console.WriteLine(person);
}

Console.WriteLine("Number of all people: " + Person.TotalPersonCount + "\n");

Console.WriteLine("-user1 add recipe to favorite list-\n");
user1.AddToFavorite(recipe3);
user1.AddToFavorite(recipe4);

Console.WriteLine("-user2 create the new recipe-\n");
user2.CreateRecipe("Omelette", "Classic omelette recipe", 5, 10, 200);

Console.WriteLine("-verification for this recipe-\n");
recipe2.Verify(false);

Console.WriteLine("-deleting user3 from the list-\n");
Person.RemovePerson(user3);

Console.WriteLine("-show the list of people-\n");
foreach (var person in Person.People)
{
    Console.WriteLine(person);
}


Console.WriteLine("------- Saving and loading recipes -------\n");

Recipe.Save(Path.Combine(Environment.CurrentDirectory, "recipes.json"), Recipe.Recipes);
var loadedRecipes = Recipe.Load(Path.Combine(Directory.GetCurrentDirectory(), "recipes.json"));
foreach (var recipe in loadedRecipes)
{
    Console.WriteLine(recipe);
}

