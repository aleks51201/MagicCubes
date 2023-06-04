using System;
using UnityEngine;

namespace MagicCubes.Config
{
    [CreateAssetMenu(fileName = "Configurations", menuName = "Config/Configurations")]
    public class Configurations : ScriptableObject
    {
        [SerializeField] private LvlHolderConfig _lvlHolderConfig;
        [SerializeField] private TextureHolder _textureHolder;


        public LvlHolderConfig LvlHolderConfig => _lvlHolderConfig;
        public TextureHolder TextureHolder => _textureHolder;
    }

    [Serializable]
    public class TextureHolder
    {
        [Header("Stars")]
        public Texture2D ObtainedStar;
        public Texture2D StarBase;
        [Space]
        [Header("Elements")]
        public Texture2D Air;
        public Texture2D Fire;
        public Texture2D Nature;
        public Texture2D Water;
    }
}
