using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//store dialogue here to be called by the Dialogue Manager
[System.Serializable]
public class Dialogue {
    public Worker worker;
    public string speaker_name;

    [TextArea(3, 10)]
    public string[] sentences;
    public string sentences_joined => string.Join(". ", sentences);

    public Dialogue()
    {

    }

    public Dialogue(Worker worker, string speaker, string[] lines)
    {
        this.worker = worker;
        if (worker != null) {
            speaker_name = worker.name;
        } else {
            speaker_name = speaker;
        }

        sentences = lines;
    }
}
