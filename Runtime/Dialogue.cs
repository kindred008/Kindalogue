using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace Kindred.Kindalogue.Runtime
{
    [System.Serializable]
    public class Dialogue
    {
        // This will override Actor set in DialogueList. Leave Null to not overrite.
        [SerializeField] private Actor m_actor = null;

        [SerializeField] private string[] m_dialogueLines;

        [SerializeField] private string[] m_choices;

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
