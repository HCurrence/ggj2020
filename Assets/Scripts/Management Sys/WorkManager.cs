using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public static readonly string[][] JOBS = {
        new [] {
            "There’s something wrong with our wiring.",
            "Could you help me fix this hole in my roof?",
            "A tree landed on our garage! We need it fixed ASAP!",
            "Could someone repair this hole in my wall?",
            "There’s a hole in my floor??? Help???",
            "Our porch and deck were wrecked by the weather, we need help fixing it. ",
            "Our A/C unit is broken.",
            "The garage door isn’t opening.",
            "This new house we bought doesn’t have proper ventilation.",
            "We have three broken windows.",
        },
        new [] {
            "Hello! We’re looking for contractors to help build a porch for our house!",
            "We want to expand our home into the backyard.",
            "Our bathroom is old and we’d like an update.",
            "I want to finish my basement, and make it into something more exciting.",
            "We need to update our kitchen.",
            "We just need to take out a wall.",
            "Hello, we’d like to add another room to our place; however, we would like a few new outlets to be connected to our electric grid as well. Is this possible?",
            "We just need to replace the insulation in our house. So that means the attic, new windows, etc. ...",
        },
        new [] {
            "Hello. I need a ramp to my house now that I’m wheelchair-bound.",
            "Greetings. Our premises needs to have ramps and elevators added to get up to code. ",
            "Hello. We’re turning a historic building into a museum, however, we need to add elevators, accessibility ramps, etc before we can begin operations.",
            "We need ramps, handrails, and some way to fix the air filtration.",
            "Good morning. We have a building code violation for a lack of fire exits. We’d like to meet with you to see what our options are.",
        },
    };

    public List<Job> orders = new List<Job>();
    public List<Worker> all_workers = new List<Worker>();
    public List<Worker> unavailable_workers = new List<Worker>();
    public List<Worker> available_workers => all_workers.Where(w => !unavailable_workers.Contains(w)).ToList();

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
            jobDesc = JOBS.Random().Random();

            professions = new List<Profession>();
            traits = new int[4];
            for (int j = 0; j < 4; j++)
            {
                professions.Add(randProfession(Random.Range(0, 6)));

                traits[j] = Random.Range(1, 6);
            }

            orders.Add(new Job(jobNum, jobDesc, NameGenerator.Inst.GetRandomName(), professions, traits));
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

            w.name = NameGenerator.Inst.GetRandomName();
            w.profession = randProfession(Random.Range(0, 7));

            w.SkinColor = Color.Lerp(SkinColors.Random(), SkinColors.Random(), Random.value);
            w.Hair = Hairs.Random();
            w.HairColor = Color.HSVToRGB(Random.value, Mathf.Lerp(0.1f, 0.9f, Random.value), Mathf.Lerp(0.5f, 0.9f, Random.value));
            w.Clothes = Clothes.Random();
            w.ClothesColor = Color.HSVToRGB(Random.value, Mathf.Lerp(0.75f, 1.0f, Random.value), 1.0f);
            w.Accessory = Accessories.Random();

            all_workers.Add(w);
            available_workers.Add(w);
        }
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
