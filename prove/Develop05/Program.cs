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


public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {

        base.RecordEvent();

        Console.WriteLine($"You completed a simple goal: {Name}");
    }
}


public class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value) { }

    public override void RecordEvent()
    {

        base.RecordEvent();

        Console.WriteLine($"You recorded an eternal goal: {Name}");
    }
}


public class ChecklistGoal : Goal
{
    public int Bonus { get; set; }

    public ChecklistGoal(string name, int value, int bonus) : base(name, value)
    {
        Bonus = bonus;
    }

    public override void RecordEvent()
    {

        base.RecordEvent();
        
        if (IsComplete && Progress % Value == 0)
        {

            Console.WriteLine($"You completed a checklist goal: {Name}");
   
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} Bonus: {Bonus}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        while (true)
        {
            Console.WriteLine("Eternal Quest - Goal Tracker");
            Console.WriteLine("1. Create a Simple Goal");
            Console.WriteLine("2. Create an Eternal Goal");
            Console.WriteLine("3. Create a Checklist Goal");
            Console.WriteLine("4. Record an Event");
            Console.WriteLine("5. List Goals");
            Console.WriteLine("6. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter goal name: ");
                    string simpleGoalName = Console.ReadLine();
                    Console.Write("Enter goal value: ");
                    int simpleGoalValue = int.Parse(Console.ReadLine());
                    goals.Add(new SimpleGoal(simpleGoalName, simpleGoalValue));
                    break;

                case 2:
                    Console.Write("Enter goal name: ");
                    string eternalGoalName = Console.ReadLine();
                    Console.Write("Enter goal value: ");
                    int eternalGoalValue = int.Parse(Console.ReadLine());
                    goals.Add(new EternalGoal(eternalGoalName, eternalGoalValue));
                    break;

                case 3:
                    Console.Write("Enter goal name: ");
                    string checklistGoalName = Console.ReadLine();
                    Console.Write("Enter goal value: ");
                    int checklistGoalValue = int.Parse(Console.ReadLine());
                    Console.Write("Enter goal bonus: ");
                    int checklistGoalBonus = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(checklistGoalName, checklistGoalValue, checklistGoalBonus));
                    break;

                case 4:
                    Console.WriteLine("Select a goal to record an event:");
                    for (int i = 0; i < goals.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {goals[i].Name}");
                    }
                    int selectedGoalIndex = int.Parse(Console.ReadLine()) - 1;
                    goals[selectedGoalIndex].RecordEvent();
                    break;

                case 5:
                    Console.WriteLine("List of Goals:");
                    foreach (var goal in goals)
                    {
                        Console.WriteLine(goal);
                    }
                    break;

                case 6:
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

