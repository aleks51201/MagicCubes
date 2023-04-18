using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Ui
{
    [Serializable]
    public class UIInitComponent : MonoBehaviour
    {
        public UIDocument UIDocument;
        public VisualTreeAsset LevelElement;
        public VisualTreeAsset LevelStar;
        public VisualTreeAsset GameUI;
    }
}
