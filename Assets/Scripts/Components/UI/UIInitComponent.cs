using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Ui
{
    [Serializable]
    public struct UIInitComponent 
    {
        public UIDocument UIDocument;
        public VisualTreeAsset LevelElement;
        public VisualTreeAsset LevelStar;
        public VisualTreeAsset GameUI;
        public VisualTreeAsset MenuUI;
    }
}
