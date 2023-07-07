using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    [CreateAssetMenu(fileName = "actor", menuName = "Kindalogue/Actor")]
    public class Actor : ScriptableObject
    {
        [SerializeField] private string m_actorUniqueId;
        [SerializeField] private string m_actorName;
        [SerializeField] private Sprite m_actorSprite;

        /// <summary>
        /// ID of the Actor. Has to be unique.
        /// </summary>
        public string UniqueId
        {
            get => m_actorUniqueId;
            internal set => m_actorUniqueId = value;
        }

        /// <summary>
        /// The visible name of the Actor.
        /// </summary>
        public string ActorName
        {
            get => m_actorName;
            internal set => m_actorName = value;
        }

        /// <summary>
        /// The visible sprite for the Actor.
        /// </summary>
        public Sprite ActorSprite
        {
            get => m_actorSprite;
            internal set => m_actorSprite = value;
        }
    }
}
