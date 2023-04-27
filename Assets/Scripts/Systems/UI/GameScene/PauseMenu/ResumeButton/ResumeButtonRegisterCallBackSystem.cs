using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public sealed class ResumeButtonRegisterCallBackSystem : IEcsRunSystem
    {
        private readonly EcsWorld _ecsWorld = null;
        private readonly EcsFilter<UIInitComponent> _uiFilter = null;
        private readonly EcsFilter<ResumeButtonComponent> _resumeBtnFilter = null;
        private readonly EcsFilter<OpenedPauseMenuEvent> _openedPauseMenuFilter = null;
        private readonly EcsFilter<ClosedPauseMenuEvent> _closedPauseMenuFilter = null;

        private const string ResumeGame = "ResumeGame";

        public void Run()
        {
            foreach (var index in _openedPauseMenuFilter)
            {
                Register(index);
            }
            foreach (var index in _closedPauseMenuFilter)
            {
                Unregister(index);
            }
        }

        private void Register(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                Button btn = _uiFilter.Get1(index).UIDocument.rootVisualElement.Q<Button>(ResumeGame);
                var resumeBtnComponent = new ResumeButtonComponent()
                {
                    Button = btn,
                    ButtonStatusHolder = new()
                };
                _ecsWorld.NewEntity().Get<ResumeButtonComponent>() = resumeBtnComponent;
                resumeBtnComponent.Button = btn;
                btn.clicked += resumeBtnComponent.ButtonStatusHolder.OnClicked;
                btn.clicked += OnClick;
            }
        }

        private void Unregister(int index)
        {
            foreach (var indexJ in _uiFilter)
            {
                foreach (var i in _resumeBtnFilter)
                {
                    Button btn = _resumeBtnFilter.Get1(i).Button;
                    var resumeBtnComponent = _resumeBtnFilter.Get1(i);
                    btn.clicked -= resumeBtnComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked -= OnClick;
                }
            }
        }

        private void OnClick()
        {
            foreach (var index in _resumeBtnFilter)
            {
                _resumeBtnFilter.GetEntity(index).Get<ResumeButtonClickEvent>();
            }
        }
    }
}
