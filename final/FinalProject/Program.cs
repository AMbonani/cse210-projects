using System;
using System.Collections.Generic;


public abstract class FitnessActivity
{
    public string Name { get; protected set; }

    public FitnessActivity(string name)
    {
        Name = name;
    }

    public abstract void PerformActivity();
}


public class User
{
    private string username;
    private int age;
    private List<FitnessActivity> activities;

    public User(string username, int age)
    {
        this.username = username;
        this.age = age;
        activities = new List<FitnessActivity>();
    }

    public void AddActivity(FitnessActivity activity)
    {
        activities.Add(activity);
    }

    public void DisplayActivities()
    {
        Console.WriteLine($"User: {username}, Age: {age}");
        Console.WriteLine("Activities:");
        foreach (var activity in activities)
        {
            Console.WriteLine($"- {activity.Name}");
        }
    }
}

public class Running : FitnessActivity
{
    public Running() : base("Running") { }


    public override void PerformActivity()
    {
        Console.WriteLine($"Running does not only benefit your body by strengthening muscles and bones it also improves your mental health and even your memory and ability to learn!");
    }
}

public class Cycling : FitnessActivity
{
    public Cycling() : base("Cycling") { }

    public override void PerformActivity()
    {
        Console.WriteLine($"Cycling is a good way to reduce weight it also raises your metabolic rate.");
    }
}

public class Weightlifting : FitnessActivity
{
    public Weightlifting() : base("Weightlifting") { }


    public override void PerformActivity()
    {
        Console.WriteLine($"Weightlifting helps build strength and muscle mass.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        User user = new User("Alphalete", 40);

        FitnessActivity running = new Running();
        FitnessActivity cycling = new Cycling();
        FitnessActivity weightlifting = new Weightlifting();

        user.AddActivity(running);
        user.AddActivity(cycling);
        user.AddActivity(weightlifting);

        user.DisplayActivities();

        // Perform activities
        Console.WriteLine("\nPerforming Activities:");
        foreach (var activity in user.activities) 
        {
            Console.WriteLine($"Activity: {activity.Name}");
            activity.PerformActivity();
            Console.WriteLine();
        }
    }
}
