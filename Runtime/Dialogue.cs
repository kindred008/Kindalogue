using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

[System.Serializable]
public class Dialogue
{
    public string speakerName;
    public string[] dialogueLines;

    public string GetDialogueString()
    {
        StringBuilder dialogueString = new StringBuilder();

        foreach(string line in dialogueLines)
        {
            dialogueString.Append(line + "\n");
        }

        return dialogueString.ToString();
    }
}
