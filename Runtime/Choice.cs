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
        
        public string ChoiceText
        {
            get => m_choiceText;
        }

        internal string NextDialogueId
        {
            get => m_nextDialogueId;
        }
    }
}
