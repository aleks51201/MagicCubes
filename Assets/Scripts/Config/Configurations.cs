using UnityEngine;

namespace MagicCubes.Config
{
    [CreateAssetMenu(fileName = "Configurations", menuName = "Config/Configurations")]
    public class Configurations : ScriptableObject
    {
        [SerializeField] private LvlHolderConfig _lvlHolderConfig;


        public LvlHolderConfig LvlHolderConfig => _lvlHolderConfig;
    }
}
