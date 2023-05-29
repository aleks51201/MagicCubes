using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public class FilStarSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<OpenedWinMenuEvent> _winFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<StarHolderComponent> _starFilter = null;

        private const string BigStarObtained1 = "BigStarObtained1";
        private const string BigStarObtained2 = "BigStarObtained2";
        private const string BigStarObtained3 = "BigStarObtained3";
        private const string BigStarStyle = "BigStarStyle";

        public void Run()
        {
            foreach (var i in _winFilter)
            {
                foreach (var j in _uiFilter)
                {
                    var visualElement = _uiFilter.Get1(j).UIDocument.rootVisualElement;
                    OpenStarAsync(visualElement);
                }
            }
        }

        private int GetCountStar()
        {
            foreach (var i in _starFilter)
            {
                return _starFilter.Get1(i).StarCount;
            }
            throw new Exception($"Component '{nameof(StarHolderComponent)}' not found");
        }

        private void OpenStarAsync(VisualElement visualElement)
        {
            string[] names = new[] { BigStarObtained1, BigStarObtained2, BigStarObtained3 };
            for (int i = 0; i < GetCountStar(); i++)
            {
                visualElement.Q(names[i]).AddToClassList(BigStarStyle);
            }
        }
    }
}
