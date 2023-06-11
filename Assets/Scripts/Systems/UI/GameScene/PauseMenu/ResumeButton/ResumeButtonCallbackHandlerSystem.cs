using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    internal sealed class ResumeButtonCallbackHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ResumeButtonClickEvent, ResumeButtonComponent> _btnFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";
        private const string GameUI = "GameUI";

        public void Run()
        {
            foreach (var index in _btnFilter)
            {
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(ButtonsUIHolder).style.display = DisplayStyle.None;
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(GameUI).style.display = DisplayStyle.Flex;
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
            }
        }
    }
}
