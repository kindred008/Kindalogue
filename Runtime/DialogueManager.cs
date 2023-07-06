using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueManager : MonoBehaviour
    {
        /// <summary>
        /// Static instance of Dialogue Manager. Accessible from any script that has this namespace in its scope.
        /// </summary>
        public static DialogueManager instance;

        private DialogueList dialogueList;

        private Dialogue m_currentDialogue;

        /// <summary>
        /// Current running Dialogue being controlled by Dialogue Manager.
        /// </summary>
        public Dialogue CurrentDialogue 
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

        /// <summary>
        /// Start new dialogue by assigning a Dialogue List to the Dialogue Manager.
        /// </summary>
        /// <param name="newDialogueList">DialogueList to assign to be managed by DialogueManager.</param>
        /// <returns>First Dialogue object from list.</returns>
        public Dialogue StartDialogue(DialogueList newDialogueList)
        {
            dialogueList = newDialogueList;
            m_currentDialogue = CreateDialogue(dialogueList.GetFirstDialogue());

            return m_currentDialogue;
        }

        /// <summary>
        /// Gets the next Dialogue Object in the current Dialogue List. Returns Null if Dialogue List is finished.
        /// </summary>
        /// <returns>Next Dialogue object from list.</returns>
        public Dialogue NextDialogue()
        {
            m_currentDialogue = CreateDialogue(dialogueList.GetNextDialogue());

            return m_currentDialogue;
        }

        public Dialogue PickChoice(Choice choice)
        {
            m_currentDialogue = CreateDialogue(dialogueList.GetNextDialogue(choice.NextDialogueId));

            return m_currentDialogue;
        }

        private Dialogue CreateDialogue(Dialogue savedDialogue)
        {
            if (savedDialogue != null)
            {
                Dialogue newDialogue = new Dialogue()
                {
                    Actor = savedDialogue.Actor ?? dialogueList.defaultActor ?? null,
                    DialogueLines = savedDialogue.DialogueLines,
                    Choices = savedDialogue.Choices,
                };

                return newDialogue;
            } else
            {
                return null;
            }
        }
    }
}
