using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    public class ActorHelper
    {
        public static Actor LoadActor(string actorFileName) 
        {
            var actor = Resources.Load<Actor>($"ScriptableObjects/{actorFileName}");

            if (actor == null)
            {
                Debug.LogWarning("Actor asset not found");
                return null;
            }

            return actor;
        }
    }
}
