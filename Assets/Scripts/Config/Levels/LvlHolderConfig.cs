using UnityEngine;

namespace MagicCubes.Config
{
    [CreateAssetMenu(fileName = "LvlHolderConfig", menuName = "Config/LvlHolderConfig")]
    public class LvlHolderConfig : ScriptableObject
    {
        [SerializeField] private string[] _sceneNames;


        public string[] SceneNames => _sceneNames;
    }
}
