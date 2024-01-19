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

   }
}

interface INgredient
{
   int Id { get; set; }
   string Name { get; set; }
   string Instructions { get; set; }
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
