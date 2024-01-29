public abstract class Car
{
    public abstract void Drive();
}

public class Ford : Car
{
    public override void Drive()
    {
        Console.WriteLine("Ford is driving.");
    }
}

public class Toyota : Car
{
    public override void Drive()
    {
        Console.WriteLine("Toyota is driving.");
    }
}

public abstract class CarFactory
{
    public abstract Car CreateCar();
}

public class FordFactory : CarFactory
{
    public override Car CreateCar()
    {
        return new Ford();
    }
}

public class ToyotaFactory : CarFactory
{
    public override Car CreateCar()
    {
        return new Toyota();
    }
}

class Client
{
    static void Main()
    {
        CarFactory fordFactory = new FordFactory();
        Car fordCar = fordFactory.CreateCar();
        fordCar.Drive();

        CarFactory toyotaFactory = new ToyotaFactory();
        Car toyotaCar = toyotaFactory.CreateCar();
        toyotaCar.Drive();
    }
}

//U klijentskom kodu, koristimo apstraktnu tvornicu (CarFactory) za stvaranje instanci konkretnih proizvoda (Ford i Toyota).








public interface Champion
{
    void Attack();
}

public class Mech : Champion
{
    private string specialEffect;

    public Mech(string specialEffect)
    {
        this.specialEffect = specialEffect;
    }

    public void Attack()
    {
        Console.WriteLine($"Mech Attack — {specialEffect}");
    }
}

public class Assassin : Champion
{
    private string ability;

    public Assassin(string ability)
    {
        this.ability = ability;
    }

    public void Attack()
    {
        Console.WriteLine($"Assassin Attack — {ability}");
    }
}

class Client
{
    static void Main()
    {
        Champion mechChampion = new Mech("Explosive Punch");
        mechChampion.Attack();

        Champion assassinChampion = new Assassin("Stealth Strike");
        assassinChampion.Attack();
    }
}

//Kod koristi implementaciju uzorka "Strategija" i pripada skupini uzoraka ponašanja. U ovom slučaju, svaki tip junaka (Champion) ima svoj vlastiti način napada koji se implementira kroz metodu Attack()


