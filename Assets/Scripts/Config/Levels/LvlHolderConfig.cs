using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagicCubes.Config
{
    [CreateAssetMenu(fileName = "LvlHolderConfig", menuName = "Config/LvlHolderConfig")]
    public class LvlHolderConfig : ScriptableObject
    {
        [SerializeField] private Scene[] _scenes;
    }
}
