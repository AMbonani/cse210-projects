using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Oracle";
        job1._startYear = 2020;
        job1._endYear = 2021;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Dell Computers";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new resume();
        myResume._name = "Abigail Mbonani";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}

