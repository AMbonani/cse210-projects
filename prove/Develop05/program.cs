using System;
using System.Collections.Generic;

public class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Progress { get; set; }
    public bool IsComplete { get; set; }

    public Goal(string name, int value)
    {
        Name = name;
        Value = value;
        Progress = 0;
        IsComplete = false;
    }

    public virtual void RecordEvent()
    {
        // Base behavior when an event is recorded
        Progress++;
        if (Progress >= Value)
        {
            IsComplete = true;
            Progress = Value;
        }
    }

    public override string ToString()
    {
        return $"{Name} [{(IsComplete ? 'X' : ' ')}] Progress: {Progress}/{Value}";
    }
}

// SimpleGoal class (inherits from Goal)
public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {
        // Override base behavior for SimpleGoal
        base.RecordEvent();
        // Add additional behavior, e.g., award points
        ScoringSystem.AddPoints(10); // Adjust the points awarded as needed
    }
}

// EternalGoal class (inherits from Goal)
public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {
        // Override base behavior for EternalGoal
        base.RecordEvent();
        // Add additional behavior, e.g., award points
        ScoringSystem.AddPoints(20); // Adjust the points awarded as needed
    }
}

// ChecklistGoal class (inherits from Goal)
public class ChecklistGoal : Goal
{
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int value, int bonus) : base(name, value)
    {
        Bonus = bonus;
    }

    public override void RecordEvent()
    {
        // Override base behavior for ChecklistGoal
        base.RecordEvent();
        // Add additional behavior, e.g., award points
        if (IsComplete && Progress % Value == 0)
        {
            // Award bonus points
            ScoringSystem.AddPoints(Bonus); // Adjust the points awarded as needed
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} Bonus: {Bonus}";
    }
}

public class ScoringSystem
{
    private static int totalPoints = 0;

    public static void AddPoints(int points)
    {
        totalPoints += points;
    }

    public static int GetTotalPoints()
    {
        return totalPoints;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        Console.WriteLine("Welcome to the Goal Management System!");
        while (true)
        {
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Create a Simple Goal");
            Console.WriteLine("2. Create an Eternal Goal");
            Console.WriteLine("3. Create a Checklist Goal");
            Console.WriteLine("4. Record Event");
            Console.WriteLine("5. View Goals");
            Console.WriteLine("6. View Total Points");
            Console.WriteLine("7. Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter the goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the goal value: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    goals.Add(new SimpleGoal(name, value));
                }
            }
            else if (choice == "2")
            {
                Console.Write("Enter the goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the goal value: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    goals.Add(new EternalGoal(name, value));
                }
            }
            else if (choice == "3")
            {
                Console.Write("Enter the goal name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the goal value: ");
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.Write("Enter the bonus value: ");
                    if (int.TryParse(Console.ReadLine(), out int bonus))
                    {
                        goals.Add(new ChecklistGoal(name, value, bonus));
                    }
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("Select a goal to record an event for:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].Name}");
                }

                if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= goals.Count)
                {
                    goals[goalIndex - 1].RecordEvent();
                    Console.WriteLine("Event recorded!");
                }
                else
                {
                    Console.WriteLine("Invalid goal selection.");
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goals:");
                foreach (var goal in goals)
                {
                    Console.WriteLine(goal);
                }
            }
            else if (choice == "6")
            {
                Console.WriteLine($"Total Points: {ScoringSystem.GetTotalPoints()}");
            }
            else if (choice == "7")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }
    }
}

