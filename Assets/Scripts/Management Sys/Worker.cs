using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Worker
{
    [Range(1, 5)]
    public int strength, trade_knowledge, tech_knowledge, professionalism;
    [Range(0, 1)]
    public float stress;
    protected float rate;
    protected bool assigned; 

    public string name;
    public WorkManager.Profession profession;

    public Worker()
    {
        strength = 0;
        trade_knowledge = 0;
        tech_knowledge = 0;
        professionalism = 0;
        stress = 0;

        rate = rateWorker();
        assigned = false;

        name = "John Doe";
        profession = WorkManager.Profession.Unemployed;
    }

    /*
     * A workers rating can be a value between 1 and 25
     */
    protected float rateWorker()
    {
        float temp = (strength + trade_knowledge + tech_knowledge + professionalism) * stress;

        if(temp > 25)
        {
            return 25;
        }
        else
        {
            return temp;
        }
    }

    public int workerStars()
    {
        return (int)(rateWorker() / 5);
    }

    public void assignedJob()
    {
        assigned = !assigned;
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
