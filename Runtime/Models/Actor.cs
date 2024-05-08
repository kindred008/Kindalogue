using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Kindred.Kindalogue.Runtime
{
    [CreateAssetMenu(fileName = "actor", menuName = "Kindalogue/Actor")]
    public class Actor : ScriptableObject
    {
        [SerializeField] private string _actorName;
        [SerializeField] private Sprite _defaultSprite;
        [SerializeField] private ActorSprite[] _sprites;

        public string ActorName
        {
            get => _actorName;
        }

        public Sprite GetActorSprite()
        {
            return _defaultSprite;
        }

        public Sprite GetActorSprite(string spriteName)
        {
            var sprite = _sprites.SingleOrDefault(x => x.Name == spriteName).Sprite ?? _defaultSprite;

            return sprite;
        }

        [Serializable]
        private struct ActorSprite
        {
            [SerializeField] private string _name;
            [SerializeField] private Sprite _sprite;

            public string Name
            {
                get => _name;
            }

            public Sprite Sprite
            {
                get => _sprite;
            }
        }
    }
}
