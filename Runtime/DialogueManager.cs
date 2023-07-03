using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private DialogueList dialogueList;

    private int currentIndex;
    [HideInInspector] public Dialogue currentDialogue;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        } else
        {
            instance = this;
        }
    }

    public void StartDialogue(DialogueList newDialogueList)
    {
        dialogueList = newDialogueList;
        currentIndex = 0;
        currentDialogue = dialogueList.GetFirstDialogue();
    }

    public bool NextDialogue()
    {
        currentDialogue = dialogueList.GetNextDialogue(currentIndex);
        currentIndex++;

        return currentDialogue != null;
    }
}
