

namespace cookies_cookbook.Recipes.Ingredients
{

   public class CocoaPowder : Ingredient
   {
      public override int Id => 7;
      public override string Name => "Cocoa powder";
      public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";
   }

}

