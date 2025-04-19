using BLGargamelLibrary;
using DALGargameLibrary;

public static class LibraryManager
{
    // Ajoute un SpellBook dans la base de données.
    public static void AddSpellBook(int serial, string title, MagicType typeOfMagic)
    {
        using (var context = new LibraryContext())
        {
            var spellBook = new SpellBook { Serial = serial, Title = title, TypeOfMagic = typeOfMagic };
            context.SpellBooks?.Add(spellBook);
            context.SaveChanges();
        }
    }

   // Ajoute un RecipeBook dans la base de données.
    public static void AddRecipeBook(int serial, string title, int numberOfRecipes)
    {
        using (var context = new LibraryContext())
        {
            var recipeBook = new RecipeBook { Serial = serial, Title = title, NumberOfRecipes = numberOfRecipes };
            context.RecipeBooks?.Add(recipeBook);
            context.SaveChanges();
        }
    }
    /// Ajoute un Book (SpellBook ou RecipeBook) en fonction des paramètres.
    public static void AddBook(int serial, string title, MagicType? typeOfMagic, int? numberOfRecipes)
    {
        using (var context = new LibraryContext())
        {
            if (typeOfMagic.HasValue && typeOfMagic != MagicType.None) // Si un type de magie est fourni, c'est un SpellBook
            {
                var spellBook = new SpellBook { Serial = serial, Title = title, TypeOfMagic = typeOfMagic.Value };
                context.SpellBooks.Add(spellBook);
            }
            else if (numberOfRecipes.HasValue) // Si un nombre de recettes est fourni, c'est un RecipeBook
            {
                var recipeBook = new RecipeBook { Serial = serial, Title = title, NumberOfRecipes = numberOfRecipes.Value };
                context.RecipeBooks.Add(recipeBook);
            }

            context.SaveChanges();
        }
    }

    // Récupère tous les SpellBooks de la base de données.
    public static List<SpellBook> GetAllSpellBooks()
    {
        using (var context = new LibraryContext())
        {
            return context.SpellBooks
                       .Where(sb => sb.TypeOfMagic != MagicType.None)
                       .ToList();
        }
    }

    //Récupère tous les RecipeBooks de la base de données.
    public static List<RecipeBook> GetAllRecipeBooks()
    {
        using (var context = new LibraryContext())
        {
            return context.RecipeBooks.ToList();
        }
    }

   // Récupère tous les livres (SpellBooks et RecipeBooks) de la base de données.
    public static List<Book> GetAllBooks()
    {
        using (var context = new LibraryContext())
        {
            var books = new List<Book>();
            books.AddRange(context.SpellBooks.ToList());
            books.AddRange(context.RecipeBooks.ToList());
            return books;
        }
    }


    // Ajoute un client dans la base de données
    public static void AddClient(string name, Speciality speciality, LevelOfMagic levelOfMagic)
    {
        using (var context = new LibraryContext())
        {
            var client = new Client
            {
                Name = name,
                Speciality = speciality,
                LevelOfMagic = levelOfMagic
            };

            context.Clients?.Add(client);
            context.SaveChanges();
        }
    }

    // Récupère tous les clients de la base de données
    public static List<Client> GetAllClients()
    {
        using (var context = new LibraryContext())
        {
            return context.Clients.ToList();
        }
    }
    public static void AddSmurf(string name, double height, SmurfDescription description)
    {
        using (var context = new LibraryContext())
        {
            var smurf = new Smurf
            {
                Name = name,
                Height = height,
                Description = description
            };

            context.Smurfs?.Add(smurf);
            context.SaveChanges();
        }
    }

    // Récupère tous les Schtroumpfs de la base de données
    public static List<Smurf> GetAllSmurfs()
    {
        using (var context = new LibraryContext())
        {
            return context.Smurfs.ToList();
        }
    }

    // Add these methods to your LibraryManager class
    public static void UpdateSmurf(int id, string name, double height, SmurfDescription description)
    {
        using (var context = new LibraryContext())
        {
            var smurf = context.Smurfs?.FirstOrDefault(s => s.Id == id);
            if (smurf != null)
            {
                smurf.Name = name;
                smurf.Height = height;
                smurf.Description = description;
                context.SaveChanges();
            }
        }
    }

    public static void DeleteSmurf(int id)
    {
        using (var context = new LibraryContext())
        {
            var smurf = context.Smurfs?.FirstOrDefault(s => s.Id == id);
            if (smurf != null)
            {
                context.Smurfs?.Remove(smurf);
                context.SaveChanges();
            }
        }
    }

    public static void AddIngredient(string name, string type, string location, string color)
    {
        using (var context = new LibraryContext())
        {
            var ingredient = new Ingredient { Name = name, Type = type, Location = location, Color = color };
            context.Ingredients?.Add(ingredient);
            context.SaveChanges();
        }
    }

    // Récupère tous les ingrédients de la base de données.
    public static List<Ingredient> GetAllIngredients()
    {
        using (var context = new LibraryContext())
        {
            return context.Ingredients?.ToList() ?? new List<Ingredient>();
        }
    }
}
