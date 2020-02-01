using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public enum Profession
    {
        Construction,
        Carpentry,
        Plumber,
        Electrictian,
        Mechanic,
        Computer_Repair,
        Archictect,
        Unemployed
    }

    public List<Job> orders = new List<Job>();
    public List<Worker> available_workers = new List<Worker>();
    public List<Worker> unavailable_workers = new List<Worker>();

    public static void generateJobs()
    {
        Random rand = new Random();
        int jobNum;
        string jobDesc;
        List<Manager.Profession> professions;
        int[] traits;

        for (int i=0; i<5; i++)
        {
            jobNum = rand.Next(1, 101);
            jobDesc = jobDescriptions(rand.Next(1, 5));

            professions = new List<Profession>();
            traits = new int[4];
            for (int j = 0; j < 4; j++)
            {
                professions.Add(randProfession(rand.Next(0, 6)));

                traits[j] = rand.Next(1, 5);
            }

            orders.Add(new Job(jobNum, jobDesc, professions, traits));
        }
    }
    public static void generateWorkers()
    {
        Random rand = new Random();

        for(int i=0; i<10; i++)
        {
            Worker w = new Worker();

            w.strength = rand.Next(1, 5);
            w.trade_knowledge = rand.Next(1, 5);
            w.tech_knowledge = rand.Next(1, 5);
            w.professionalism = rand.Next(1, 5);

            w.stress = rand.Next(1, 10);

            w.name = randNames(Rand(1, 5));
            w.profession = randProfession;

            available_workers.Add(w);
        }
    }

    public static void vacation(Worker w)
    {
        available_workers.Remove(w);
        unavailable_workers.Add(w);
    }

    public static string jobDescriptions(int randNum)
    {
        switch(randNum)
        {
            case 1:
                return "Help me renovate my house!";
            case 2:
                return "I need you to install a few accessability renovations at my office.";
            case 3:
                return "My A/C is broken.";
            case 4:
                return "Could someone repair this hole in my wall?";
            case 5:
                return "Waste Management";
        }
    }

    public static string randNames(int randNum)
    {
        switch (randNum)
        {
            case 1:
                return "Rando Mando";
            case 2:
                return "Pia";
            case 3:
                return "Momin";
            case 4:
                return "Haley";
            case 5:
                return "Yolanda";
        }
    }

    public static Profession randProfession(int randNum)
    {
        switch (randNum)
        {
            case 0:
                return Profession.Archictect;
            case 1:
                return Profession.Carpentry;
            case 2:
                return Profession.Computer_Repair;
            case 3:
                return Profession.Construction;
            case 4:
                return Profession.Electrictian;
            case 5:
                return Profession.Mechanic;
            case 6:
                return Profession.Plumber;
        }
    }

}
