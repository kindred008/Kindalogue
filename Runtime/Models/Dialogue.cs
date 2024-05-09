using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class Dialogue
    {
        private string _id;

        private string _goto;

        private Actor _actor;

        private string[] _dialogueLines;

        public string Id
        {
            get => _id;
        }

        public string Goto
        {
            get => _goto;
        }

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

        public Dialogue(string id, string gotoId, Actor actor, string[] dialogueLines)
        {
            _id = id;
            _goto = gotoId;
            _actor = actor;
            _dialogueLines = dialogueLines;
        }
    }
}
