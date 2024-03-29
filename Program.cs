﻿using System.Net;
using cookies_cookbook.Recipes;
using cookies_cookbook.Recipes.Ingredients;

var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(), new RecipesConsoleUserInteraction(new IngredientsRegister()));



cookiesRecipesApp.Run("recipes.txt");

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
   public void Run(string filePath)
   {
      var allRecipes = _recipesRepository.Read(filePath);
      _recipesUserInteraction.PrintExistingRecipes(allRecipes);
      _recipesUserInteraction.PromptToCreateRecipe();

      var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

      if (ingredients.Count() > 0)
      {
         var recipe = new Recipe(ingredients);
         allRecipes.Add(recipe);
         // _recipesRepository.Write(filePath, allRecipes);
         _recipesUserInteraction.ShowMessage("Recipe added:");
         _recipesUserInteraction.ShowMessage(recipe.ToString());
      }
      else
      {
         _recipesUserInteraction.ShowMessage("No ingredients were selected. Recipes will not be saved.");
      }

      _recipesUserInteraction.Exit();
   }
}



public interface IRecipesUserInteraction
{
   void ShowMessage(string message);
   void Exit();
   void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
   void PromptToCreateRecipe();
   IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public class IngredientsRegister
{
   public IEnumerable<Ingredient> All { get; } = new List<Ingredient>{
      new WheatFlour(),
      new Butter(),
      new Chocolate(),
      new Sugar(),
      new Cardamom(),
      new Cinnamon(),
      new CocoaPowder(),
   };

   public Ingredient GetById(int id)
   {
      foreach (var ingredient in All)
      {
         if (ingredient.Id == id)
         {
            return ingredient;
         }
      }

      return null;
   }
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
   private readonly IngredientsRegister _ingredientsRegister;
   public RecipesConsoleUserInteraction(IngredientsRegister ingredientsRegister)
   {
      _ingredientsRegister = ingredientsRegister;
   }
   public void ShowMessage(string message)
   {
      System.Console.WriteLine(message);
   }

   public void Exit()
   {
      System.Console.WriteLine("Press any key to exit...");
      Console.ReadKey();
   }

   public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
   {
      if (allRecipes.Count() > 0)
      {
         System.Console.WriteLine($"Existing recipes are: {Environment.NewLine}");
         var counter = 1;
         foreach (var recipe in allRecipes)

         {
            System.Console.WriteLine($"***** {counter}********");
            System.Console.WriteLine(recipe);
            System.Console.WriteLine();
            counter++;
         }
      }
   }

   public void PromptToCreateRecipe()
   {
      System.Console.WriteLine("Create a new cookie recipe!" + "Available ingredients are:");

      foreach (var ingredient in _ingredientsRegister.All)
      {
         System.Console.WriteLine(ingredient);
      }
   }

   public IEnumerable<Ingredient> ReadIngredientsFromUser()
   {
      bool shallStop = false;
      var ingredients = new List<Ingredient>();

      while (!shallStop)
      {
         System.Console.WriteLine("Add an ingredient by its ID, " + "or type anything else if finished.");

         var userInput = Console.ReadLine();

         if (int.TryParse(userInput, out int id))
         {
            var selectedIngredient = _ingredientsRegister.GetById(id);
            if (selectedIngredient is not null)
            {
               ingredients.Add(selectedIngredient);
            }
         }
         else
         {
            shallStop = true;
         }
      }

      return ingredients;
   }

}

public interface IRecipesRepository
{
   List<Recipe> Read(string filePath);
}

public class RecipesRepository : IRecipesRepository
{
   public List<Recipe> Read(string filePath)
   {
      return new List<Recipe>
      {
         new Recipe(new List<Ingredient>
         {
            new WheatFlour(),
            new Sugar(),
            new Butter()
         }),
         new Recipe(new List<Ingredient>
         {
            new CocoaPowder(),
            new CoconutFlour(),
            new Cinnamon()
         })
      };
   }
}
