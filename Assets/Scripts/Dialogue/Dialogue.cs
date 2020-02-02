using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//store dialogue here to be called by the Dialogue Manager
[System.Serializable]
public class Dialogue
{
    public string speaker_name;

    [TextArea(3, 10)]
    public string[] sentences;

    public Dialogue()
    {

    }

    public Dialogue(string name, string[] lines)
    {
        speaker_name = name;

        sentences = lines;
    }
}
