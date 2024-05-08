using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation
{
    private string _defaultActor;

    private Dialogue[] _dialogues;

    public string DefaultActor
    {
        get => _defaultActor;
        set => _defaultActor = value;
    }

    public Dialogue[] Dialogues
    {
        get => _dialogues;
        set => _dialogues = value;
    }

    public Conversation(string defaultActor, Dialogue[] dialogues)
    {
        _defaultActor = defaultActor;
        _dialogues = dialogues;
    }
}
