using System.Net;

var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(), new RecipesUserInteraction());
cookiesRecipesApp.Run();

public class CookiesRecipesApp
{
   private readonly IRecipesRepository _recipesRepository;
   private readonly IRecipesUserInteraction _recipesUserInteraction;

   // passing dependency as parameter in constructor (instead of creating them at declaration) to provide flexibility to the code
   public CookiesRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
   {
      _recipesRepository = recipesRepository;
      _recipesUserInteraction = recipesUserInteraction;
   }
   public void Run()
   {
      var allRecipes = _recipesRepository.GetAll(filePath);
      _recipesUserInteraction.DisplayRecipes(allRecipes);
      _recipesUserInteraction.PromptForRecipe();

      var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

      if (ingredients.Count > 0)
      {
         var recipes = new Recipe(ingredients);
         allRecipes.Add(recipes);
         _recipesRepository.Write(filePath, allRecipes);
         _recipesUserInteraction.ShowMessage("Recipe added:");
         _recipesUserInteraction.ShowMessage(recipes.ToString());
      }
      else
      {
         _recipesUserInteraction.ShowMessage("No ingredients were selected. Recipes will not be saved.");
      }

      _recipesUserInteraction.Exit();
   }
}

public interface IRecipesRepository
{
}

public interface IRecipesUserInteraction
{
   void ShowMessage(string message);
   void Exit();
}

public class RecipesUserInteraction : IRecipesUserInteraction
{
   public void ShowMessage(string message)
   {
      System.Console.WriteLine(message);
   }

   public void Exit()
   {
      System.Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
   }
}
