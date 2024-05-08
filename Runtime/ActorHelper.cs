using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class ActorHelper
    {
        private Dictionary<string, Actor> _actorDictionary;

        public ActorHelper()
        {
            _actorDictionary = new Dictionary<string, Actor>();
        }

        public Actor LoadActor(string actorFileName) 
        {
            if (_actorDictionary.ContainsKey(actorFileName))
            {
                return _actorDictionary[actorFileName];
            }

            var actor = Resources.Load<Actor>(actorFileName);

            if (actor == null)
            {
                Debug.LogWarning("Actor asset not found");
                return null;
            }

            _actorDictionary.Add(actorFileName, actor);
            return actor;
        }

        public void ClearCache()
        {
            _actorDictionary = new Dictionary<string, Actor>();
        }
    }
}
