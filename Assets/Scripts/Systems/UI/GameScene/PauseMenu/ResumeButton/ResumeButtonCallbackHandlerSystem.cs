using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    internal sealed class ResumeButtonCallbackHandlerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ResumeButtonClickEvent, ResumeButtonComponent> _btnFilter = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;

        private const string ButtonsUIHolder = "ButtonsUIHolder";
        private const string GameUI = "GameUI";

        public void Run()
        {
            foreach (var index in _btnFilter)
            {
                _btnFilter.GetEntity(index).Del<ResumeButtonClickEvent>();
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(ButtonsUIHolder).style.display = DisplayStyle.None;
                _uiFilter.Get1(index).UIDocument.rootVisualElement.Q(GameUI).style.display = DisplayStyle.Flex;
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
                _world.NewEntity().Get<ClosedPauseMenuEvent>();
            }
        }
    }
}
