using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    [System.Serializable]
    public class Choice
    {
        [SerializeField] private string m_choiceText;

        [SerializeField] private string m_nextDialogueId;
        
        /// <summary>
        /// Text that accompanies a choice so player knows what choice is. 
        /// </summary>
        public string ChoiceText
        {
            get => m_choiceText;
        }

        /// <summary>
        /// ID of Dialogue from DialogueList to go to after making this choice. 
        /// </summary>
        internal string NextDialogueId
        {
            get => m_nextDialogueId;
        }
    }
}
