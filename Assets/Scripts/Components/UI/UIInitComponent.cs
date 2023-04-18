using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Ui
{
    [Serializable]
    public class UIInitComponent : MonoBehaviour
    {
        public UIDocument _uiDocument;
        public VisualTreeAsset _levelElement;
        public VisualTreeAsset _levelStar;
        public VisualTreeAsset _gameUI;
    }
}
