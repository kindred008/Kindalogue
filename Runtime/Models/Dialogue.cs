using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    private string _actor;

    private string[] _dialogueLines;

    public string Actor
    {
        get => _actor;
        set => _actor = value;
    }

    public string[] DialogueLines
    {
        get => _dialogueLines; 
        set => _dialogueLines = value;
    }

    public Dialogue(string actor, string[] dialogueLines) 
    {
        _actor = actor;
        _dialogueLines = dialogueLines;
    }
}
