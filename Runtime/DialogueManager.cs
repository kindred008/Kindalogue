using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager instance;

        private DialogueList dialogueList;

        private int currentIndex;

        private Dialogue m_currentDialogue;

        public Dialogue currentDialogue 
        { 
            get 
            {
                return m_currentDialogue;
            }
            private set 
            {
                m_currentDialogue = value;
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        public void StartDialogue(DialogueList newDialogueList)
        {
            dialogueList = newDialogueList;
            currentIndex = 0;
            m_currentDialogue = dialogueList.GetFirstDialogue();
        }

        public bool NextDialogue()
        {
            m_currentDialogue = dialogueList.GetNextDialogue(currentIndex);
            currentIndex++;

            return m_currentDialogue != null;
        }
    }
}
