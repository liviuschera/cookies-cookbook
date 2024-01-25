

using cookies_cookbook.Recipes.Ingredients;

namespace cookies_cookbook.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }
        public Recipe(IEnumerable<Ingredient> ingredients) => Ingredients = ingredients;
    }

}
