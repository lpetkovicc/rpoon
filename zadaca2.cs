using System;

public class Employee
{

    public void CalculateBonus()
    {
        Console.WriteLine("Iznos bonusa");
    }


    public void SendSalary()
    {
       Console.WriteLine("Slanje place");
    }
}
//ovo krši SRP jer klasa ima više od jedne odgovornosti (izdracun bonusa i slanje place). Da bi to popravili mozemo odvojiti metode u posebne klase npr.







public class Player
{

    public virtual void Attack()
    {
        Console.WriteLine($"performs a basic attack.");
    }
}

public class Wizzard : Player
{
    public override void Attack()
    {
        Console.WriteLine($"casts a spell.");
    }
}

public class Warrior : Player
{
    public override void Attack()
    {
        Console.WriteLine($"swings a sword.");
    }
}


public class GameManager
{
    public void StartGame(Player player)
    {
        player.Attack();
    }
}

//ako želimo dodati novi tip igrača (npr. Archer), morali bismo promneniti postojeći kod i dodati novu klasu koja nasleđuje Player.

//Ovo krši OCP jer se kod mora mijenjati svaki put kada želimo dodati novi tip igrača. Bolje rješenje bilo bi koristiti interface








public class Dog
{
    public void Bark()
    {
        Console.WriteLine("Woof! Woof!");
    }
}

public class RobotDog : Dog
{
    public void ChargeBattery()
    {
        Console.WriteLine("Charging battery...");
    }
}

public class DogOwner
{
    public void CommandDogBark(Dog dog)
    {
        dog.Bark();
    }
}

class Program
{
    static void Main()
    {
        DogOwner dogOwner = new DogOwner();
        Dog myDog = new RobotDog();
        dogOwner.CommandDogBark(myDog); 
    }
}

//Ovo krši LSP jer RobotDog nije potpuno zamenljiv za Dog u svim kontekstima gde se očekuje instanca klase Dog. Kada koristimo RobotDog u kontekstu gde se očekuje Dog, može doći do neočekivanog ponašanja ili grešaka.//
//rjesnje je koristenje interfacea koji ce podrzat sve vrste pasa



public interface IShip
{
    void Swim();
    void FireCannons();
    void LoadCargo();
}

// Implementacija interfejsa za teretni brod
public class CargoShip : IShip
{
    public void Swim()
    {
        Console.WriteLine("Swimming...");
    }

    public void FireCannons()
    {
        
        throw new InvalidOperationException("Cargo ship cannot fire cannons.");
    }

    public void LoadCargo()
    {
        Console.WriteLine("Loading cargo...");
    }
}

public class WarShip : IShip
{
    public void Swim()
    {
        Console.WriteLine("Swimming...");
    }

    public void FireCannons()
    {
        Console.WriteLine("Firing cannons!");
    }

    public void LoadCargo()
    {
        
        throw new InvalidOperationException("War ship cannot load cargo.");
    }
}

class Program
{
    static void Main()
    {
        IShip cargoShip = new CargoShip();
        cargoShip.Swim();
        cargoShip.FireCannons(); 

        IShip warShip = new WarShip();
        warShip.Swim();
        warShip.LoadCargo(); 
}

 //U ovom primjeru, sučelje IShip sadrži tri metode (Swim, FireCannons, LoadCargo) koje predstavljaju osnovne funkcionalnosti za sve brodove. Međutim, teretni brod (CargoShip) ne može pucati topovima, a ratni brod (WarShip) nema potrebu za metodom LoadCargo. Oba broda su prisiljena implementirati sve tri metode, čime se krši ISP. Bolje rješenje bilo bi razbiti IShip sučelje na više specifičnih sučelja, svaki s vlastitim skupom metoda.






  
public class Student
{
    public void Study()
    {
        Console.WriteLine($"is studying...");
    }
}

public class Subject
{
    private readonly Student student;

    public Subject(Student student)
    {
        this.student = student;
    }

    public void StudySubject()
    {
        student.Study();
        Console.WriteLine($"Studying the subject.");
    }
}

class Program
{
    static void Main()
    {
        Student student = new Student();
        Subject mathSubject = new Subject(student);
        mathSubject.StudySubject();
    }
}

    //U ovom primjeru, "Subject" direktno zavisi od "Student", što krši DIP. Kada kreiramo objekt "Subject", moramo prosljediti instancu "Student", čime se stvara direktna zavisnost između ova dva modula.

    //Bolje rješenje bilo bi koristiti apstrakciju(sučelje ili apstraktnu klasu)






