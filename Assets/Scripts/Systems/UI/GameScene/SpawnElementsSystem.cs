using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Config;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class SpawnElementsSystem : IEcsInitSystem
    {
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly Configurations _configurations;

        private const string IconsHolder = "IconsHolder";
        private const string Icon = "Icon";


        public void Init()
        {
            Dictionary<Elements, Texture2D> elementsMap = new()
            {
                [Elements.Air] = _configurations.TextureHolder.Air,
                [Elements.Fire] = _configurations.TextureHolder.Fire,
                [Elements.Nature] = _configurations.TextureHolder.Nature,
                [Elements.Water] = _configurations.TextureHolder.Water,
            };
            foreach (int i in _uiFilter)
            {
                foreach (var j in _configurations.LvlHolderConfig.LvlData)
                {
                    foreach (var k in j.Elements)
                    {
                        VisualElement visualElement = _uiFilter.Get1(i).UIDocument.rootVisualElement.Q(IconsHolder);
                        VisualElement childElement = _uiFilter.Get1(i).IconTemplate.Instantiate();
                        VisualElement icon = childElement.Q(Icon);
                        icon.style.backgroundImage = elementsMap[k];
                        visualElement.Add(childElement);
                    }
                }
            }
        }
    }
}
