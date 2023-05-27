using System;
using UnityEngine;

namespace MagicCubes.Config
{
    [CreateAssetMenu(fileName = "LvlHolderConfig", menuName = "Config/LvlHolderConfig")]
    public class LvlHolderConfig : ScriptableObject
    {
        [SerializeField] private LvlData[] _lvlData;


        public LvlData[] LvlData => _lvlData;
    }

    [Serializable]
    public class LvlData
    {
        public string SceneName;
        public int NumStepForLoseSecondStar;
        public int NumStepForLoseThirdStar;
        public Texture2D Texture2D;
    }
}
