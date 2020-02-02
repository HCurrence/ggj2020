using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript
{
    string playerName = GameManager.Inst.name;

    public Dialogue randomSickDayDialogue(Worker w)
    {
        Dialogue d = new Dialogue();
        d.speaker_name = w.name;

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

    public Dialogue randomVacationDialogue(Worker w)
    {
        Dialogue d = new Dialogue();
        d.speaker_name = w.name;

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

    public Dialogue randomWorkerComplaintDialogue(Worker w, Worker other)
    {
        Dialogue d = new Dialogue();
        d.speaker_name = w.name;

        string[] script = null;

        switch (Random.Range(1, 4))
        {
            case 1:
                script = new string[] { "Hey, " + playerName + ", can I not work with " + other.name + "?", "We are having problems." };
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

    public Dialogue randomCustomerReviewPosDialogue(string customerName)
    {
        Dialogue d = new Dialogue();
        d.speaker_name = customerName;

        string[] script = null;

        switch (Random.Range(1, 5))
        {
            case 1:
                script = new string[] { "Great job, done quick, no sweat!" };
                break;
            case 2:
                script = new string[] { "they did good" };
                break;
            case 3:
                script = new string[] { "Completely satisfied with the results and the service. Consider me a returning client!! " };
                break;
            case 4:
                script = new string[] { "They did a super awesome job! 11/10!!!" };
                break;
            case 5:
                script = new string[] { "Solid work" };
                break;
        }

        d.sentences = script;

        return d;
    }

    public Dialogue randomCustomerReviewNegDialogue(Worker w)
    {
        Dialogue d = new Dialogue();
        d.speaker_name = w.name;

        string[] script = null;

        switch (Random.Range(1, 5))
        {
            case 1:
                script = new string[] { "Horrible. I don’t know what went wrong but everyone was completely unprofessional." };
                break;
            case 2:
                script = new string[] { "The work was alright, the employees could’ve been better." };
                break;
            case 3:
                script = new string[] { "10/10 would not contract again" };
                break;
            case 4:
                script = new string[] { "This was the worst waste of money ever!!! Will NOT be seeing you again!" };
                break;
            case 5:
                script = new string[] { "I totally didn’t get what I paid for. " };
                break;
        }

        d.sentences = script;

        return d;
    }
}
