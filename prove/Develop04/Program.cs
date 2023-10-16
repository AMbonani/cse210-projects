using System;
using System.Threading;


public class Activity
{
    private string name;
    protected int duration; 

    public Activity(string name)
    {
        this.name = name;
    }

    public void SetDuration(int duration)
    {
        this.duration = duration;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine($"Duration: {duration} seconds");
        Console.WriteLine("Get ready to start in 5 seconds...");
        Thread.Sleep(1000);
    }

    public void End()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"Completed {name} activity in {duration} seconds");
        Thread.Sleep(2000);
    }

    public void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($" {i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}


public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing") { }

    public void Execute()
    {
        Start();
        Console.WriteLine("This breathing exercise will help you relax and clear your mind");

        for (int i = 0; i < duration;)
        {
            Console.WriteLine("Breathe in...");
            Pause(3);

            i += 3;
            if (i >= duration)
                break;

            Console.WriteLine("Breathe out...");
            Pause(3);
            i += 3;
        }

        End();
    }
}


public class ReflectionActivity : Activity
{
    public ReflectionActivity() : base("Reflection") { }

    public void Execute()
    {
        Start();
        Console.WriteLine("This activity will help you reflect on times in your life when you have shown courage and strength. This will remind you of the power you posess.");

        string[] prompts = {
            "Think of a time when you accomplished a task you thought was impossible.",
            "Think of a time when you did something you have never done before",
            "Think of a time when you helped someone in need.",
            "Think of a time when you wanted to give up."
        };

        Random random = new Random();

        for (int i = 0; i < duration;)
        {
            string randomPrompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(randomPrompt);

            string[] questions = {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                Pause(5);
            }

            i += 5;
        }

        End();
    }
}


public class ListingActivity : Activity
{
    public ListingActivity() : base("Listing") { }

    public void Execute()
    {
        Start();
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        string[] prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        Random random = new Random();

        for (int i = 0; i < duration;)
        {
            string randomPrompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(randomPrompt);

            Console.WriteLine("You have 10 seconds to start listing...");
            Pause(10);

            Console.WriteLine("Enter your list (one item per line):");
            int itemCount = 0;
            string input;
            do
            {
                input = Console.ReadLine();
                itemCount++;
            } while (!string.IsNullOrWhiteSpace(input));
            itemCount--; 

            Console.WriteLine($"You listed {itemCount} items.");
            i += 10;
        }

        End();
    }
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 4)
            {
                break;
            }

            Activity activity = null;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    continue;
            }

            Console.WriteLine("Enter the duration in seconds:");
            int duration = int.Parse(Console.ReadLine());
            activity.SetDuration(duration);

            
            if (activity is BreathingActivity breathingActivity)
            {
                breathingActivity.Execute();
            }
            else if (activity is ReflectionActivity reflectionActivity)
            {
                reflectionActivity.Execute();
            }
            else if (activity is ListingActivity listingActivity)
            {
                listingActivity.Execute();
            }
        }
    }
}
