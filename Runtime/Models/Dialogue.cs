using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class Dialogue
    {
        private Actor _actor;

        private string[] _dialogueLines;

        public Actor Actor
        {
            get => _actor;
            set => _actor = value;
        }

        public string[] DialogueLines
        {
            get => _dialogueLines;
            set => _dialogueLines = value;
        }

        public Dialogue(Actor actor, string[] dialogueLines)
        {
            _actor = actor;
            _dialogueLines = dialogueLines;
        }
    }
}
