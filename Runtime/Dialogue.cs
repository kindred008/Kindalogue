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

        /// <summary>
        /// UniqueID of this Dialogue. Allows Dialogue or Choices to link to this Dialogue object. This should be unique within a DialogueList.
        /// </summary>
        public string UniqueId
        {
            get => m_uniqueId;
        }

        /// <summary>
        /// Who is performing this Dialogue. This will override default Actor set in DialogueList. Leave Null to not overrite.
        /// </summary>
        public Actor Actor
        {
            get => m_actor;
            set => m_actor = value;
        }

        /// <summary>
        /// An array of strings that make up this dialogue line by line.
        /// </summary>
        public string[] DialogueLines
        {
            get => m_dialogueLines;
            set => m_dialogueLines = value;
        }

        /// <summary>
        /// Array of choices that can be made.
        /// </summary>
        public Choice[] Choices
        {
            get => m_choices;
            set => m_choices = value;
        }

        /// <summary>
        /// ID of Dialogue from DialogueList to go to next.
        /// </summary>
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
