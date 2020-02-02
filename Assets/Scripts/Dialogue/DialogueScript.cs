using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript
{

    public static Dialogue randomSickDayDialogue(Worker w)
    {
        Dialogue d = new Dialogue(w, null, null);

        string[] script = null;

        switch (Random.Range(1, 5))
        {
            case 1:
                script = new string[]{ "Hello, I’m sorry to say that I will be unavailable to work today due to health concerns." };
                break;
            case 2:
                script = new string[] { "Sorry, I can’t come in today.", "I’m sick." };
                break;
            case 3:
                script = new string[] { "i’m super sick dude i gotta stay home" };
                break;
            case 4:
                script = new string[] { "Hey, I really need a mental health day.", "I hope you understand." };
                break;
            case 5:
                script = new string[] { "Good Morning.", "Just letting you know that I caught the Flu, and I wont be coming today.", "Sorry for the inconvenience..." };
                break;
        }

        d.sentences = script;

        return d;
    }

    public static Dialogue randomVacationDialogue(Worker w)
    {
        Dialogue d = new Dialogue(w, null, null);

        string[] script = null;

        switch (Random.Range(1, 3))
        {
            case 1:
                script = new string[] { "Hi!", "Just a reminder that I am on vacation today!", "Thanks!" };
                break;
            case 2:
                script = new string[] { "i'm taking a vacay" };
                break;
            case 3:
                script = new string[] { "This is a reminder that I will be at the beach today.", "I'll bring you a souvenir!" };
                break;
            case 4:
                script = new string[] { "" };
                break;
            case 5:
                script = new string[] { "" };
                break;
        }

        d.sentences = script;

        return d;
    }

    public static Dialogue randomWorkerComplaintDialogue(Worker w, Worker other)
    {
        Dialogue d = new Dialogue(w, null, null);

        string[] script = null;

        switch (Random.Range(1, 4))
        {
            case 1:
                script = new string[] { "Hey, " + GameManager.Inst.Name + ", can I not work with " + other.name + "?", "We are having problems." };
                break;
            case 2:
                script = new string[] { "I would like to request that I am not on a team with " + other.name + ".", "They know what they did." };
                break;
            case 3:
                script = new string[] { "Hello.", "If possible, could I not be assigned with " + other.name + "?", "We are clearly incompatible with each other." };
                break;
            case 4:
                script = new string[] { "Don't pair me with " + other.name + "." };
                break;
            case 5:
                script = new string[] { "" };
                break;
        }

        d.sentences = script;

        return d;
    }
}
