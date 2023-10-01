using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        
        Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        
        Console.WriteLine("Press Enter to start hiding words or type 'quit' to exit.");
        Console.WriteLine("Full Scripture:");
        scripture.Display();

        while (true)
        {
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;

            
            scripture.HideRandomWords();
            Console.Clear();
            Console.WriteLine("Press Enter to continue hiding words or type 'quit' to exit.");
            scripture.Display();

            
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Program will exit.");
                break;
            }
        }
    }
}

class Scripture
{
    private string reference;
    private List<Word> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void Display()
    {
        Console.WriteLine($"{reference}:");
        foreach (Word word in words)
        {
            Console.Write(word.IsHidden ? "***** " : word.Text + " ");
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(1, 4); 

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(words.Count);
            words[index].Hide();
        }
    }

    public bool AllWordsHidden()
    {
        return words.All(word => word.IsHidden);
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }
}
