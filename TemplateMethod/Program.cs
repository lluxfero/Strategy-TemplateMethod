SpaghettiBolognese spaghetti = new();
Client.ClientCode(spaghetti);

CaesarSalad salad = new();
Client.ClientCode(salad);


class Client
{
    public static void ClientCode(Recipe recipe)
    {
        recipe.Cook();
        Console.WriteLine();
    }
}

abstract class Recipe
{
    public void Cook()
    {
        Prepare();
        CookIngredient();
        AddSauce();
        Garnish();
        Serve();
    }

    protected abstract void Prepare();

    protected abstract void CookIngredient();

    protected abstract void AddSauce();

    protected virtual void Garnish()
    {
        Console.WriteLine("No garnish added");
    }

    protected abstract void Serve();
}

class SpaghettiBolognese : Recipe
{
    protected override void Prepare()
    {
        Console.WriteLine("Preparing spaghetti bolognese...");
        Console.WriteLine("Boil spaghetti and set aside");
        Console.WriteLine("Chop onion, garlic, and carrots");
    }

    protected override void CookIngredient()
    {
        Console.WriteLine("Heat oil in a pan and fry onions and garlic");
        Console.WriteLine("Add minced meat and cook until browned");
        Console.WriteLine("Add chopped carrots and cook for 5 minutes");
        Console.WriteLine("Add canned tomatoes, tomato paste, and water");
        Console.WriteLine("Add Italian herbs and black pepper to taste");
        Console.WriteLine("Cook for 20-30 minutes until sauce thickens");
    }

    protected override void AddSauce()
    {
        Console.WriteLine("Pour the bolognese sauce over the spaghetti");
    }

    protected override void Garnish()
    {
        Console.WriteLine("Sprinkle grated Parmesan cheese on top");
    }

    protected override void Serve()
    {
        Console.WriteLine("Serve hot");
    }
}

class CaesarSalad : Recipe
{
    protected override void Prepare()
    {
        Console.WriteLine("Preparing Caesar salad...");
        Console.WriteLine("Wash and tear the lettuce into bite-size pieces");
        Console.WriteLine("Prepare the croutons");
    }

    protected override void CookIngredient()
    {
        Console.WriteLine("Fry bacon until crisp and chop into small pieces");
        Console.WriteLine("Boil an egg for 1 minute, cool and chop it");
    }

    protected override void AddSauce()
    {
        Console.WriteLine("Add Caesar dressing and toss well");
    }

    protected override void Garnish()
    {
        Console.WriteLine("Add the bacon, egg, and croutons on top");
    }

    protected override void Serve()
    {
        Console.WriteLine("Serve chilled");
    }
}

//Preparing spaghetti bolognese...
//Boil spaghetti and set aside
//Chop onion, garlic, and carrots
//Heat oil in a pan and fry onions and garlic
//Add minced meat and cook until browned
//Add chopped carrots and cook for 5 minutes
//Add canned tomatoes, tomato paste, and water
//Add Italian herbs and black pepper to taste
//Cook for 20-30 minutes until sauce thickens
//Pour the bolognese sauce over the spaghetti
//Sprinkle grated Parmesan cheese on top
//Serve hot

//Preparing Caesar salad...
//Wash and tear the lettuce into bite-size pieces
//Prepare the croutons
//Fry bacon until crisp and chop into small pieces
//Boil an egg for 1 minute, cool and chop it
//Add Caesar dressing and toss well
//Add the bacon, egg, and croutons on top
//Serve chilled