

namespace cookies_cookbook.Recipes.Ingredients
{
   public abstract class Flour : Ingredient
   {
      public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
   }
}

