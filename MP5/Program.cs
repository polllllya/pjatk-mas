using Microsoft.EntityFrameworkCore;
using MP5;

public class Program
{
    public static void Main(string[] args)
    {
        var connectionString = "Data Source=identifier.sqlite";
        
        using (var context = new Context(connectionString))
        {
            // new Users
            var user1 = new User("Alice", "Smith");
            var user2 = new User("Bob", "Johnson");
            var user3 = new User("Charlie", "Brown");
            var user4 = new User("Diana", "Ross");
            
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            
            Console.WriteLine("Dodano nowego użytkownika: " + user1.Name);
            Console.WriteLine("Dodano nowego użytkownika: " + user2.Name);
            Console.WriteLine("Dodano nowego użytkownika: " + user3.Name);
            Console.WriteLine("Dodano nowego użytkownika: " + user4.Name);
            
            // new Recipes + association 1:* 
            var recipe1 = new Recipe("Spaghetti Bolognese", "Classic spaghetti bolognese recipe", 20, 30, 400)
            {
                Creator = user1
            };
            
            var recipe2 = new Recipe("Chicken Curry", "A rich and creamy chicken curry", 25, 40, 500)
            {
                Creator = user1
            };

            var recipe3 = new Recipe("Vegetable Stir Fry", "Quick and healthy vegetable stir fry", 15, 10, 200)
            {
                Creator = user3
            };

            var recipe4 = new Recipe("Beef Stroganoff", "Tender beef in a creamy mushroom sauce", 30, 45, 600)
            {
                Creator = user1
            };
            
            context.Recipes.Add(recipe1);
            context.Recipes.Add(recipe2);
            context.Recipes.Add(recipe3);
            context.Recipes.Add(recipe4);
            
            Console.WriteLine("Dodano nowy przepis: " + recipe1.Name);
            Console.WriteLine("Dodano nowy przepis: " + recipe2.Name);
            Console.WriteLine("Dodano nowy przepis: " + recipe3.Name);
            Console.WriteLine("Dodano nowy przepis: " + recipe4.Name);
            
            // association *:* 
            user2.AddToFavorite(recipe1);
            user2.AddToFavorite(recipe2);
            user2.AddToFavorite(recipe3);
            user3.AddToFavorite(recipe4);
            
            Console.WriteLine(user2.Name + " dodał do ulubionych przepis: " + recipe1.Name);
            Console.WriteLine(user2.Name + " dodał do ulubionych przepis: " + recipe2.Name);
            Console.WriteLine(user2.Name + " dodał do ulubionych przepis: " + recipe3.Name);
            Console.WriteLine(user3.Name + " dodał do ulubionych przepis: " + recipe4.Name);
            
            context.SaveChanges();

            Console.WriteLine("\nLista użytkowników:");
            foreach (var user in context.Users)
            {
                Console.WriteLine(user.Name + " " + user.Surname);
            }

            Console.WriteLine("\nLista przepisów:");
            foreach (var recipe in context.Recipes.Include(r => r.Creator))
            {
                Console.WriteLine(recipe.Name + " created by " + recipe.Creator.Name);
            }

            Console.WriteLine("\nUlubione przepisy User2:");
            var userWithFavorite = context.Users.Include(u => u.FavoriteRecipes).FirstOrDefault(u => u.Name == "Bob");
            if (userWithFavorite != null)
            {
                foreach (var favorite in userWithFavorite.FavoriteRecipes)
                {
                    Console.WriteLine(favorite.Name);
                }
            }
            
            // dziedziczenie 
            var childrenRecipe = new ChildrenRecipe("Kids Spaghetti", "Kid-friendly spaghetti recipe", 15, 20, 300, 12, 4, "Serve with fun shapes")
            {
                Creator = user1
            };
            context.ChildrenRecipes.Add(childrenRecipe);
            Console.WriteLine("Dodano nowy przepis dla dzieci: " + childrenRecipe.Name);
            
            context.SaveChanges();
            
            // usuwanie uzytkownika i przepisu
            var userToRemove = context.Users.Include(u => u.FavoriteRecipes).FirstOrDefault(u => u.Name == "Charlie");
            if (userToRemove != null)
            {
                userToRemove.FavoriteRecipes.Clear();
                context.Users.Remove(userToRemove);
            }
        
            var recipeToRemove = context.Recipes.FirstOrDefault(r => r.Name == "Spaghetti Bolognese");
            if (recipeToRemove != null)
            {
                context.Recipes.Remove(recipeToRemove);
            }
        
            context.SaveChanges();
        
            Console.WriteLine("\nPo usunięciu: ");

            Console.WriteLine("\nLista użytkowników:");
            foreach (var user in context.Users)
            {
                Console.WriteLine(user.Name + " " + user.Surname);
            }

            Console.WriteLine("\nLista przepisów:");
            foreach (var recipe in context.Recipes.Include(r => r.Creator))
            {
                if (recipe.Creator != null)
                {
                    Console.WriteLine(recipe.Name + " created by " + recipe.Creator.Name);
                }
                else
                {
                    Console.WriteLine(recipe.Name + " (Creator unknown)");
                }
            }

            Console.WriteLine("\nUlubione przepisy User2:");
            var userWithFavoriteAfterRemoval = context.Users.Include(u => u.FavoriteRecipes).FirstOrDefault(u => u.Name == "Bob");
            if (userWithFavoriteAfterRemoval != null)
            {
                foreach (var favorite in userWithFavoriteAfterRemoval.FavoriteRecipes)
                {
                    Console.WriteLine(favorite.Name);
                }
            }
        }
    }
}
