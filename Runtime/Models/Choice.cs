using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class Choice : Node
    {
        private string _choiceText;

        public string ChoiceText
        {
            get => _choiceText;
            set => _choiceText = value;
        }

        public Choice(string id, string gotoId, string choiceText)
        {
            _id = id;
            _goto = gotoId;
            _choiceText = choiceText;
        }

        public override string ToString()
        {
            return ChoiceText;
        }
    }
}
