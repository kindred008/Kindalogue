using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class Conversation
    {
        private Dialogue[] _dialogues;

        public Dialogue[] Dialogues
        {
            get => _dialogues;
            set => _dialogues = value;
        }

        public Conversation(Dialogue[] dialogues)
        {
            _dialogues = dialogues;
        }

        public Dialogue GetFirstDialogue => _dialogues[0];

        public Dialogue GetDialogue(string dialogueId) => _dialogues.SingleOrDefault(x => x.Id == dialogueId);
    }
}
