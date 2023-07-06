using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class DialogueList : MonoBehaviour
    {
        public Actor defaultActor = null;

        [SerializeField] private List<Dialogue> dialogueList = new List<Dialogue>();

        private int currentIndex;

        /// <summary>
        /// Gets the first Dialogue object for the conversation.
        /// </summary>
        /// <returns>Dialogue object</returns>
        internal Dialogue GetFirstDialogue()
        {
            currentIndex = 0;
            return dialogueList[0];
        }

        /// <summary>
        /// Gets the next Dialogue object for a conversation based on given index.
        /// </summary>
        /// <param name="currentIndex">The index of where currently are in Dialogue List.</param>
        /// <returns>Dialogue object</returns>
        internal Dialogue GetNextDialogue()
        {
            currentIndex = currentIndex + 1;
            if (currentIndex < dialogueList.Count)
            {
                return dialogueList[currentIndex];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the Dialogue object with specified uniqueId from the list. 
        /// </summary>
        /// <param name="dialogueId">The uniqueId for the dialogue to get.</param>
        /// <returns>Dialogue object</returns>
        internal Dialogue GetNextDialogue(string dialogueId)
        {
            var dialogue = dialogueList.First(x => x.UniqueId == dialogueId);
            currentIndex = dialogueList.FindIndex(x => x == dialogue);

            return dialogue;
        }
    }
}
