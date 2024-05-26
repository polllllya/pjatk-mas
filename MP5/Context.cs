namespace MP5;

using Microsoft.EntityFrameworkCore;
public class Context : DbContext
{
    private readonly string _connectionString;

    public Context(string connectionString)
    {
        _connectionString = connectionString;
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasOne(r => r.Creator)
            .WithMany(u => u.CreatedRecipes)
            .HasForeignKey(r => r.CreatorId)
            .OnDelete(DeleteBehavior.Cascade); 

        modelBuilder.Entity<User>()
            .HasMany(u => u.FavoriteRecipes)
            .WithMany(r => r.FavoritedByUsers)
            .UsingEntity<Dictionary<string, object>>(
                "UserFavoriteRecipes",
                j => j.HasOne<Recipe>().WithMany().OnDelete(DeleteBehavior.Cascade), 
                j => j.HasOne<User>().WithMany().OnDelete(DeleteBehavior.Cascade)); 

        modelBuilder.Entity<Recipe>()
            .HasDiscriminator<string>("RecipeType")
            .HasValue<Recipe>("Recipe")
            .HasValue<ChildrenRecipe>("ChildrenRecipe");
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<ChildrenRecipe> ChildrenRecipes { get; set; }
}

