using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI
{
    internal sealed class LevelChooseButtonCallbackHandlerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<LvlChooseButtonClickEvent, LevelChooseBtnComponent, LevelElementComponent> _btnFilter = null;


        public void Run()
        {
            foreach (var index in _btnFilter)
            {
                _btnFilter.GetEntity(index).Del<LvlChooseButtonClickEvent>();
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                CurrentLvlComponent currentLvlComponent = new()
                {
                    Id = _btnFilter.Get3(index).Id,
                    SceneName = _btnFilter.Get3(index).SceneName
                };
                _world.NewEntity().Get<CurrentLvlComponent>() = currentLvlComponent;
                SceneManager.LoadScene(_btnFilter.Get3(index).SceneName);
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
            }
        }
    }
}
