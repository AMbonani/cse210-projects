using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Writing a new entry...");
                        journal.WriteEntry();
                        break;
                    case 2:
                        Console.WriteLine("Displaying the journal:");
                        journal.DisplayEntries();
                        break;
                    case 3:
                        Console.Write("Enter a filename to save the journal: ");
                        string filename = Console.ReadLine();
                        journal.SaveJournalToFile(filename);
                        break;
                    case 4:
                        Console.Write("Enter a filename to load the journal from: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadJournalFromFile(loadFilename);
                        break;
                    case 5:
                        continueRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteEntry()
    {
        Console.WriteLine("Select a prompt for your entry:");
        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {prompts[i]}");
        }

        Console.Write("Enter choice number: ");
        if (int.TryParse(Console.ReadLine(), out int promptIndex) && promptIndex >= 1 && promptIndex <= prompts.Count)
        {
            Console.Write("Enter your response: ");
            string response = Console.ReadLine();
            DateTime date = DateTime.Now;

            JournalEntry entry = new JournalEntry(prompts[promptIndex - 1], response, date);
            entries.Add(entry);
        }
        else
        {
            Console.WriteLine("Invalid , Please select a valid prompt.");
        }
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }

        Console.WriteLine($"Journal saved to {filename}.");
    }

    public void LoadJournalFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        DateTime date = DateTime.Parse(parts[0]);
                        string prompt = parts[1];
                        string response = parts[2];

                        JournalEntry entry = new JournalEntry(prompt, response, date);
                        entries.Add(entry);
                    }
                }
            }

            Console.WriteLine($"Journal loaded from {filename}.");
        }
        else
        {
            Console.WriteLine("file does not exist.");
        }
    }
}

class JournalEntry
{
    public string Prompt { get; }
    public string Response { get; }
    public DateTime Date { get; }

    public JournalEntry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}
