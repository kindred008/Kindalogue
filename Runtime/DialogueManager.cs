using Kindred.Kindalogue.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueManager : MonoBehaviour
    {
        private static DialogueManager _instance;

        public static DialogueManager Instance
        {
            get => _instance;
            private set => _instance = value;
        }

        [Header("XML Configuration")]
        [SerializeField] private string _dialogueRoot = "Dialogue";
        [SerializeField] private string _actorRoot = "ScriptableObjects/Actors";

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
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }

            _xmlReader = new XMLReader(_dialogueRoot, _actorRoot);
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
            }
            else
            {
                if (CurrentDialogue.Choices.Length > 0 && !CurrentDialogue.ChoiceMade)
                {
                    Debug.LogWarning("Need to make choice");
                    return null;
                }

                var nextDialogueId = CurrentDialogue.Goto;

                if (string.IsNullOrEmpty(nextDialogueId))
                {
                    _dialogueFinished = true;
                    Debug.Log("Dialogue finished");
                    return null;
                }

                CurrentDialogue = CurrentConversation.GetDialogue(nextDialogueId);
                CurrentDialogue.ChoiceMade = false;
            }

            return CurrentDialogue;
        }

        public bool MakeChoice(string choiceId)
        {
            if (CurrentDialogue == null || _dialogueFinished || CurrentDialogue.Choices.Length == 0)
            {
                Debug.LogWarning("No choice to make");
                return false;
            }

            var choice = CurrentDialogue.Choices.SingleOrDefault(x => x.Id == choiceId);

            if (choice == null)
            {
                Debug.LogWarning("Choice doesn't exist");
                return false;
            }

            CurrentDialogue.Goto = choice.Goto;
            CurrentDialogue.ChoiceMade = true;

            return true;
        }
    }
}
