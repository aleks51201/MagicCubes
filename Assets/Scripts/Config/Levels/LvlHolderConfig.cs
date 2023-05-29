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
        public Elements[] Elements;
    }

    public enum Elements
    {
        Air = 1,
        Fire = 2,
        Nature = 3,
        Water = 4,
    }
}
