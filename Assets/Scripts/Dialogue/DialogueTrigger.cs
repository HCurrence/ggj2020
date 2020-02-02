using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Attach this script to an object to trigger dialogue.
 */
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void triggerDialogue()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }
}
