using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class Dialogue: Node
    {
        private Actor _actor;

        private string[] _dialogueLines;

        private Choice[] _choices;

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

        public Choice[] Choices
        {
            get => _choices;
            set => _choices = value;
        }

        public Dialogue(string id, string gotoId, Actor actor, string[] dialogueLines, Choice[] choices)
        {
            _id = id;
            _goto = gotoId;
            _actor = actor;
            _dialogueLines = dialogueLines;
            _choices = choices;
        }

        public override string ToString()
        {
            return Actor.ActorName + ": " + Environment.NewLine + string.Join(Environment.NewLine, DialogueLines);
        }
    }
}
