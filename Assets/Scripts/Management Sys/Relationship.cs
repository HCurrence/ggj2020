using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship : MonoBehaviour
{
    public Worker person;

    [Range(0, 10)]
    public double status;

    public Relationship(Worker w, int stat)
    {
        person = w;
        status = stat;
    }
}
