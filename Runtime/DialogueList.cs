using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueList : MonoBehaviour
    {
        public List<Dialogue> dialogueLists = new List<Dialogue>();

        public Dialogue GetFirstDialogue()
        {
            return dialogueLists[0];
        }

        public Dialogue GetNextDialogue(int currentIndex)
        {
            var nextIndex = currentIndex + 1;
            if (nextIndex < dialogueLists.Count)
            {
                return dialogueLists[nextIndex];
            }
            else
            {
                return null;
            }
        }
    }
}
