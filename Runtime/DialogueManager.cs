using Kindred.Kindalogue.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(XMLReader))]
public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    public static DialogueManager Instance
    {
        get => _instance;
        private set => _instance = value;
    }

    private Conversation _currentConversation;
    private Dialogue _currentDialogue;

    private XMLReader _xmlReader;

    private bool _dialogueFinished = false;

    public Conversation CurrentConversation
    {
        get => _currentConversation;
        private set => _currentConversation = value;
    }

    public Dialogue CurrentDialogue
    {
        get => _currentDialogue;
        private set => _currentDialogue = value;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        } else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _xmlReader = GetComponent<XMLReader>();
    }

    public void LoadConversation(string fileName)
    {
        CurrentConversation = null;
        CurrentDialogue = null;
        _dialogueFinished = false;

        CurrentConversation = _xmlReader.ReadDialogueFile(fileName);
    }

    public Dialogue GetNextDialogue()
    {
        if (CurrentConversation == null)
        {
            Debug.LogError("Conversation not loaded");
            return null;
        }

        if (CurrentDialogue == null && !_dialogueFinished)
        {
            CurrentDialogue = CurrentConversation.GetFirstDialogue;
        } else
        {
            var nextDialogueId = CurrentDialogue.Goto;

            if (string.IsNullOrEmpty(nextDialogueId))
            {
                _dialogueFinished = true;
                Debug.Log("Dialogue finished");
                return null;
            }

            CurrentDialogue = CurrentConversation.GetDialogue(nextDialogueId);
        }

        return CurrentDialogue;
    }
}
