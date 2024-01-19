using System.Net;

var cookiesRecipesApp = new CookiesRecipesApp();
cookiesRecipesApp.Run();

public class CookiesRecipesApp
{
   private readonly RecipesRepository _recipesRepository;
   private readonly RecipesUserInteraction _recipesUserInteraction;

   public CookiesRecipesApp(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
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

public class RecipesUserInteraction
{
   public void ShowMessage(string message)
   {
      System.Console.WriteLine(message); ;
   }

   public void Exit()
   {
      System.Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
   }
}

public class RecipesRepository
{
}

public abstract class Ingredient
{
   public abstract void Prepare();
}

public abstract class WheatFlour : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Sieve. Add to other ingredients.");
}

public abstract class CoconutFlour : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Sieve. Add to other ingredients.");
}

public abstract class Sugar : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Add to other ingredients.");
}

public abstract class Chocolate : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Melt in a water bath. Add to other ingredients.");
}

public abstract class Cardamom : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Take half a teaspoon. Add to other ingredients.");
}

public abstract class Cinnamon : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Take half a teaspoon. Add to other ingredients.");
}

public abstract class CocoaPowder : Ingredient
{
   public override void Prepare() => System.Console.WriteLine("Take half a teaspoon. Add to other ingredients.");
}
