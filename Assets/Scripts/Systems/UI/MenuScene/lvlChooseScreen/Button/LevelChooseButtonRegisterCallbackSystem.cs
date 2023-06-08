using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    internal sealed class LevelChooseButtonRegisterCallbackSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartButtonClickedEvent, StartMenuLevelChooseScreenComponent> _clickedFilter = null;
        private readonly EcsFilter<LevelElementComponent> _lvlChooseBtnFilter = null;

        public void Run()
        {
            foreach (var _ in _clickedFilter)
            {
                foreach (var index in _lvlChooseBtnFilter)
                {
                    Button btn = _lvlChooseBtnFilter.Get1(index).LvlElement.Q<Button>("LevelButton");
                    LevelChooseBtnComponent levelChooseBtnComponent = new()
                    {
                        Button = btn,
                        ButtonStatusHolder = new()
                    };
                    _lvlChooseBtnFilter.GetEntity(index).Get<LevelChooseBtnComponent>() = levelChooseBtnComponent;
                    btn.clicked += levelChooseBtnComponent.ButtonStatusHolder.OnClicked;
                    btn.clicked += OnClick;
                }
            }
        }

        private void OnClick()
        {
            foreach (var index in _lvlChooseBtnFilter)
            {
                _lvlChooseBtnFilter.GetEntity(index).Get<LvlChooseButtonClickEvent>();
            }
        }
    }
}
