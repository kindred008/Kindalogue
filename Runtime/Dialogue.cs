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
        public Actor actor = null;

        public string[] dialogueLines;

        public override string ToString()
        {
            StringBuilder dialogueString = new StringBuilder();

            foreach (string line in dialogueLines)
            {
                dialogueString.Append(line + "\n");
            }

            return dialogueString.ToString();
        }
    }
}
