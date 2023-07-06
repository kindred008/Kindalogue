using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Kindred.Kindalogue.Runtime
{
    [System.Serializable]
    public class Dialogue
    {
        [SerializeField] private string m_uniqueId;

        // This will override Actor set in DialogueList. Leave Null to not overrite.
        [SerializeField] private Actor m_actor = null;

        [SerializeField] private string[] m_dialogueLines;

        [SerializeField] private Choice[] m_choices;

        [SerializeField] private string m_nextDialogueId;

        public string UniqueId
        {
            get => m_uniqueId;
        }

        public Actor Actor
        {
            get => m_actor;
            set => m_actor = value;
        }

        public string[] DialogueLines
        {
            get => m_dialogueLines;
            set => m_dialogueLines = value;
        }

        public Choice[] Choices
        {
            get => m_choices;
            set => m_choices = value;
        }

        internal string NextDialogueId
        {
            get => m_nextDialogueId;
        }

        public override string ToString()
        {
            StringBuilder dialogueString = new StringBuilder();

            foreach (string line in DialogueLines)
            {
                dialogueString.Append(line + "\n");
            }

            return dialogueString.ToString();
        }
    }
}
