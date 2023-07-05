using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueList : MonoBehaviour
    {
        public Actor defaultActor = null;

        [SerializeField] private List<Dialogue> dialogueList = new List<Dialogue>();

        /// <summary>
        /// Gets the first Dialogue object for the conversation.
        /// </summary>
        /// <returns>Dialogue object</returns>
        internal Dialogue GetFirstDialogue()
        {
            return dialogueList[0];
        }

        /// <summary>
        /// Gets the next Dialogue object for a conversation based on given index.
        /// </summary>
        /// <param name="currentIndex">The index of where currently are in Dialogue List.</param>
        /// <returns>Dialogue object</returns>
        internal Dialogue GetNextDialogue(int currentIndex)
        {
            var nextIndex = currentIndex + 1;
            if (nextIndex < dialogueList.Count)
            {
                return dialogueList[nextIndex];
            }
            else
            {
                return null;
            }
        }
    }
}
