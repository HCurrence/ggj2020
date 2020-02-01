using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkManager : Manager<WorkManager>
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

    public void generateJobs(int num)
    {
        int jobNum;
        string jobDesc;
        List<Profession> professions;
        int[] traits;

        for (int i=0; i<num; i++)
        {
            jobNum = Random.Range(1, 101);
            jobDesc = jobDescriptions(Random.Range(1, 5));

            professions = new List<Profession>();
            traits = new int[4];
            for (int j = 0; j < 4; j++)
            {
                professions.Add(randProfession(Random.Range(0, 6)));

                traits[j] = Random.Range(1, 5);
            }

            orders.Add(new Job(jobNum, jobDesc, professions, traits));
        }
    }
    public void generateWorkers(int num)
    {
        for(int i=0; i<num; i++)
        {
            Worker w = new Worker();

            w.strength = Random.Range(1, 5);
            w.trade_knowledge = Random.Range(1, 5);
            w.tech_knowledge = Random.Range(1, 5);
            w.professionalism = Random.Range(1, 5);

            w.stress = Random.Range(1, 10);

            w.name = NameGenerator.Inst.GetRandomFirstName() + " " + NameGenerator.Inst.GetRandomLastName();
            w.profession = randProfession(Random.Range(0, 6));

            available_workers.Add(w);
        }
    }

    public void vacation(Worker w)
    {
        available_workers.Remove(w);
        unavailable_workers.Add(w);
    }

    public string jobDescriptions(int randNum)
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

        return "Job goes here";
    }

    public Profession randProfession(int randNum)
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

        return Profession.Unemployed;
    }

}
