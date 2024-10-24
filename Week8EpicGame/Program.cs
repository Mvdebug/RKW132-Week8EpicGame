string folderPath = @"C:\Programming\Data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "magic wand", "spoon", "banana", "sword", "knife" };

//string[] heroes = {"Harry Potter", "Luke Skywalker", "Lara Croft", "Scooby-Doo" };
//string[] villains = { "Voldemort", "Darth Vader", "Dracula", "Joker", "Sauron" };


string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrenght = heroHP;
Console.WriteLine($"Today {hero} ({heroHP}) with {heroWeapon} saves the day!");


string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP}) with {villainWeapon} tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP =villainHP - Hit(hero, heroStrikeStrenght);
}

Console.WriteLine($"{hero} HP {heroHP}");
Console.WriteLine($"{villain} HP {villainHP}");

if(heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if(villainHP > 0)
{
    Console.WriteLine($"{villain} came out on top");
}
else
{
    Console.WriteLine("Disaster for both!");
}


static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next( 0, someArray.Length );
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}

static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10) 
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }

}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if(strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }

    return strike;
}