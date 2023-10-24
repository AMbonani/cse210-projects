using System;
using System.Collections.Generic;

public abstract class FitnessActivity
{
    public string Name { get; protected set; }

    public FitnessActivity(string name)
    {
        Name = name;
    }

    // Default constructor
    public FitnessActivity() { }

    public abstract void PerformActivity();
}

public class User
{
    private string username;
    private int age;
    private List<FitnessActivity> activities;
    private int weightGoal;
    private int runningGoalKilometers;
    private int gymHoursGoal;
    private int totalScore;

    public User(string username, int age)
    {
        this.username = username;
        this.age = age;
        activities = new List<FitnessActivity>();
        weightGoal = 0;
        runningGoalKilometers = 0;
        gymHoursGoal = 0;
        totalScore = 0;
    }

    public void SetGoals(int weightGoal, int runningGoalKilometers, int gymHoursGoal)
    {
        this.weightGoal = weightGoal;
        this.runningGoalKilometers = runningGoalKilometers;
        this.gymHoursGoal = gymHoursGoal;
    }

    public void AddActivity(FitnessActivity activity)
    {
        activities.Add(activity);
    }

    public void DisplayGoals()
    {
        Console.WriteLine($"User: {username}, Age: {age}");
        Console.WriteLine($"Weight Goal: {weightGoal} kg");
        Console.WriteLine($"Running Goal: {runningGoalKilometers} km");
        Console.WriteLine($"Gym Hours Goal: {gymHoursGoal} hours");
    }

    public void DisplayActivities()
    {
        Console.WriteLine("Activities:");
        for (int i = 0; i < activities.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {activities[i].Name}");
        }
    }

    public List<FitnessActivity> GetActivities()
    {
        return activities;
    }

    public void UpdateScore(int score)
    {
        totalScore += score;
        Console.WriteLine($"Total Score: {totalScore}");
        if (totalScore >= weightGoal && totalScore >= runningGoalKilometers && totalScore >= gymHoursGoal)
        {
            Console.WriteLine("Congratulations! You have achieved all your goals!");
        }
    }
}

public class Running : FitnessActivity
{
    public Running() : base("Running") { }

    public override void PerformActivity()
    {
        Console.WriteLine($"Running does not only benefit your body by strengthening muscles and bones, it also improves your mental health and even your memory and ability to learn!");
    }
}

public class Cycling : FitnessActivity
{
    public Cycling() : base("Cycling") { }

    public override void PerformActivity()
    {
        Console.WriteLine($"Cycling is a good way to reduce weight, and it also raises your metabolic rate.");
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
        Console.WriteLine("Welcome to the Fitness App!");
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your age: ");
        if (int.TryParse(Console.ReadLine(), out int age))
        {
            User user = new User(username, age);

            Console.Write("Enter your weight loss goal (in kg): ");
            if (int.TryParse(Console.ReadLine(), out int weightGoal))
            {
                Console.Write("Enter your running goal (in kilometers): ");
                if (int.TryParse(Console.ReadLine(), out int runningGoalKilometers))
                {
                    Console.Write("Enter your weekly gym hours goal: ");
                    if (int.TryParse(Console.ReadLine(), out int gymHoursGoal))
                    {
                        user.SetGoals(weightGoal, runningGoalKilometers, gymHoursGoal);

                        FitnessActivity running = new Running();
                        FitnessActivity cycling = new Cycling();
                        FitnessActivity weightlifting = new Weightlifting();

                        user.AddActivity(running);
                        user.AddActivity(cycling);
                        user.AddActivity(weightlifting);

                        while (true)
                        {
                            Console.WriteLine("\nChoose an activity to perform:");
                            user.DisplayActivities();
                            int choice;

                            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= user.GetActivities().Count)
                            {
                                FitnessActivity selectedActivity = user.GetActivities()[choice - 1];
                                Console.WriteLine($"\nPerforming {selectedActivity.Name} activity:");
                                selectedActivity.PerformActivity();
                                Console.Write("Enter the score for this activity: ");
                                if (int.TryParse(Console.ReadLine(), out int score))
                                {
                                    user.UpdateScore(score);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input for score.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice. Please select a valid activity.");
                            }

                            Console.Write("Do you want to perform another activity? (Y/N): ");
                            string response = Console.ReadLine();
                            if (response != null && response.ToLower() != "y")
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input for gym hours goal.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input for running goal.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for weight loss goal.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for age.");
        }
    }
}




