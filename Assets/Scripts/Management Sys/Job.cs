using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Job
{
    [SerializeField]
    protected int job_number;
    [SerializeField]
    protected string job_description;

    [SerializeField]
    protected List<WorkManager.Profession> compatible_professions;
    [SerializeField]
    protected List<Worker> workers;

    //4 item integer array
    /*
     * 0 - Strength
     * 1 - Trade knowledge
     * 2 - Tech Knowledge
     * 3 - Professionalism
     */
    int[] team_trait_expectation;

    protected bool complete;

    public Job()
    {
        job_number = -1;
        job_description = "N/A";

        workers = new List<Worker>();
        compatible_professions = new List<WorkManager.Profession>();

        complete = false;

        team_trait_expectation = new int[4];
    }
    public Job(int num, string desc, List<WorkManager.Profession> list, int[] expectedValues)
    {
        job_number = num;
        job_description = desc;

        workers = new List<Worker>();
        compatible_professions = list;

        team_trait_expectation = expectedValues;
    }

    public void setJobNumber(int num)
    {
        job_number = num;
    }
    public void setDescription(string desc)
    {
        job_description = desc;
    }
 
    public void addWorker(Worker w)
    {
        if (!workers.Contains(w))
        {
            workers.Add(w);
            w.assignedJob();
        }
    }
    public void removeWorker(Worker w)
    {
        workers.Remove(w);
        w.assignedJob();
    }
    public void setCompatibleProfessions(List<WorkManager.Profession> list)
    {
        compatible_professions.AddRange(list);
    }

    public int getJobNumber()
    {
        return job_number;
    }
    public string getDescription()
    {
        return job_description;
    }
    
    //Returns job satisfaction factor
    public double checkJobCompatibility(Worker w)
    {
        double factor = 0;
        if(compatible_professions.Contains(w.profession))
        {
            factor += w.workerStars() * 0.2;
        }
        else
        {
            factor -= w.workerStars() * 0.2;
        }

        //lowest factor value
        if (factor == 0)
        {
            factor = 0.1;
        }

        return factor;
    }

    public double completeJob()
    {
        //calculate score by worker assignment
        int sum_expected = 0;
        foreach (int x in team_trait_expectation)
        {
            sum_expected += x;
        }

        for(int i =0; i<team_trait_expectation.Length; i++)
        {
            team_trait_expectation[i] = 0;
            foreach (Worker w in workers)
            {
                switch(i)
                {
                    case 0:
                        team_trait_expectation[i] += w.strength;
                        break;
                    case 1:
                        team_trait_expectation[i] += w.trade_knowledge;
                        break;
                    case 2:
                        team_trait_expectation[i] += w.tech_knowledge;
                        break;
                    case 3:
                        team_trait_expectation[i] += w.professionalism;
                        break;
                }
            }
        }

        float final_score = 0;
        foreach (int x in team_trait_expectation)
        {
            final_score += x / sum_expected;
        }

        float stress_average = 0;
        double job_compatibility = 0;
        foreach (Worker w in workers)
        {
            stress_average += w.stress;
            w.stress++;

            job_compatibility += checkJobCompatibility(w);
        }
        stress_average /= workers.Count;

        return (final_score*100) - (stress_average*9.5) + job_compatibility;
    }

    public void evaluateWorkerRelationships(double finalScore)
    {
        Worker[] people = workers.ToArray();

        Relationship[] relationshipsA, relationshipsB;
        Relationship a, b;
        for(int i=0; i<people.Length; i++) //A
        {
            for(int j=(i+1); i<people.Length-1; i++) //B
            {
                relationshipsA = people[i].social_life.ToArray();
                int index = searchSocial(people[j], relationshipsA);
                b = relationshipsA[index]; //b in a

                relationshipsB = people[j].social_life.ToArray();
                index = searchSocial(people[i], relationshipsB);
                a = relationshipsB[index]; //a in b

                if(finalScore>80)
                {
                    a.status = a.status + relationshipModValue(a) * 2;
                    b.status = b.status + relationshipModValue(b) * 2;
                }
                else if(finalScore<20)
                {
                    a.status = a.status - relationshipModValue(a) * 2;
                    b.status = b.status - relationshipModValue(b) * 2;
                }
                else
                {
                    a.status = a.status + relationshipModValue(a);
                    b.status = b.status + relationshipModValue(b);
                }
            }
        }
    }

    private int searchSocial(Worker w, Relationship[] arr)
    {
        Relationship r;
        for(int i=0; i<arr.Length; i++)
        {
            if(arr[i].name == w.name)
            {
                return i;
            }
        }

        return -1;
    }

    private double relationshipModValue(Relationship r)
    {
        if (r.status < 2)
        {
            return 0.5;
        }
        else if (r.status == 3)
        {
            return 1;
        }
        else if(r.status > 4 && r.status < 6)
        {
            return 0.5;
        }
        else if(r.status == 7)
        {
            return 1;
        }
        else if(r.status > 8)
        {
            return 0.5;
        }
        else
        {
            return 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
