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

    public List<Job> jobs = new List<Job>();
    public List<Worker> available_workers = new List<Worker>();
    public List<Worker> unavailable_workers = new List<Worker>();

    public static void generateJobs()
    {

    }
    public static void generateWorkers()
    {

    }

    public static void vacation(Worker w)
    {
        available_workers.Remove(w);
        unavailable_workers.Add(w);
    }





}
