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

    public Color[] SkinColors;
    public Sprite[] Hairs;
    public Sprite[] Clothes;
    public Sprite[] Accessories;

    public void generateJobs(int num)
    {
        int jobNum;
        string jobDesc;
        List<Profession> professions;
        int[] traits;

        for (int i=0; i<num; i++)
        {
            jobNum = Random.Range(1, 101);
            jobDesc = jobDescriptionRandom();

            professions = new List<Profession>();
            traits = new int[4];
            for (int j = 0; j < 4; j++)
            {
                professions.Add(randProfession(Random.Range(0, 6)));

                traits[j] = Random.Range(1, 6);
            }

            orders.Add(new Job(jobNum, jobDesc, professions, traits));
        }
    }
    public void generateWorkers(int num)
    {
        for(int i=0; i<num; i++)
        {
            Worker w = new Worker();

            w.strength = Random.Range(1, 6);
            w.trade_knowledge = Random.Range(1, 6);
            w.tech_knowledge = Random.Range(1, 6);
            w.professionalism = Random.Range(1, 6);

            w.stress = Random.Range(1, 10);

            w.name = NameGenerator.Inst.GetRandomFirstName() + " " + NameGenerator.Inst.GetRandomLastName();
            w.profession = randProfession(Random.Range(0, 7));

            w.SkinColor = Color.Lerp(SkinColors.Random(), SkinColors.Random(), Random.value);
            w.Hair = Hairs.Random();
            w.HairColor = Color.HSVToRGB(Random.value, Mathf.Lerp(0.1f, 0.9f, Random.value), Mathf.Lerp(0.5f, 0.9f, Random.value));
            w.Clothes = Clothes.Random();
            w.ClothesColor = Color.HSVToRGB(Random.value, Mathf.Lerp(0.75f, 1.0f, Random.value), 1.0f);
            w.Accessory = Accessories.Random();

            available_workers.Add(w);
        }
    }

    public void workerUnavailable(Worker w)
    {
        available_workers.Remove(w);
        unavailable_workers.Add(w);
    }

    public string jobDescriptionRandom()
    {
        switch(Random.Range(1, 4))
        {
            case 1:
                return jobDescriptionAccessibility(Random.Range(1, 5));
            case 2:
                return jobDescriptionComputerRepair(Random.Range(1, 5));
            case 3:
                return jobDescriptionHomeRepair(Random.Range(1, 10));
            case 4:
                return jobDescriptionRenovation(Random.Range(1, 8));
        }

        return "Job Not Found";
    }

    public string jobDescriptionHomeRepair(int randNum)
    {
        switch (randNum)
        {
            case 1:
                return "There’s something wrong with our wiring.";
            case 2:
                return "Could you help me fix this hole in my roof?";
            case 3:
                return "A tree landed on our garage! We need it fixed ASAP!";
            case 4:
                return "Could someone repair this hole in my wall?";
            case 5:
                return "There’s a hole in my floor??? Help???";
            case 6:
                return "Our porch and deck were wrecked by the weather, we need help fixing it. ";
            case 7:
                return "Our A/C unit is broken.";
            case 8:
                return "The garage door isn’t opening.";
            case 9:
                return "This new house we bought doesn’t have proper ventilation.";
            case 10:
                return "We have three broken windows.";
        }

        return "Job goes here";
    }

    public string jobDescriptionRenovation(int randNum)
    {
        switch (randNum)
        {
            case 1:
                return "Hello! We’re looking for contractors to help build a porch for our house!";
            case 2:
                return "We want to expand our home into the backyard.";
            case 3:
                return "Our bathroom is old and we’d like an update.";
            case 4:
                return "I want to finish my basement, and make it into something more exciting.";
            case 5:
                return "We need to update our kitchen.";
            case 6:
                return "We just need to take out a wall.";
            case 7:
                return "Hello, we’d like to add another room to our place; however, we would like a few new outlets to be connected to our electric grid as well. Is this possible?";
            case 8:
                return "We just need to replace the insulation in our house. So that means the attic, new windows, etc. ...";
        }

        return "Job goes here";
    }

    public string jobDescriptionAccessibility(int randNum)
    {
        switch (randNum)
        {
            case 1:
                return "Hello. I need a ramp to my house now that I’m wheelchair-bound.";
            case 2:
                return "Greetings. Our premises needs to have ramps and elevators added to get up to code. ";
            case 3:
                return "Hello. We’re turning a historic building into a museum, however, we need to add elevators, accessibility ramps, etc before we can begin operations.";
            case 4:
                return "We need ramps, handrails, and some way to fix the air filtration.";
            case 5:
                return "Good morning. We have a building code violation for a lack of fire exits. We’d like to meet with you to see what our options are.";
        }

        return "Job goes here";
    }

    public string jobDescriptionComputerRepair(int randNum)
    {
        switch (randNum)
        {
            case 1:
                return "My computer keeps clicking. Is that bad?";
            case 2:
                return "Tl:dr; my phone was ran over. Can you fix it??";
            case 3:
                return "My laptop never connects to wifi! >.<";
            case 4:
                return "I need a new LCD.";
            case 5:
                return "That Nigerian prince gave my computer a STD";
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
