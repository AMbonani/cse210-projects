using System;

class Program
{
    static void Main(string[] args)
    {
       
        Assignment a1 = new Assignment("Kano Mbonani", "Fractions");
        Console.WriteLine(a1.GetSummary());

        
        MathAssignment a2 = new MathAssignment("Kabo Mbonani", "Addition", "8.1", "7-10");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Gugu Sibiya", "African Studies", "The Rise of the Zulu Kindom");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}