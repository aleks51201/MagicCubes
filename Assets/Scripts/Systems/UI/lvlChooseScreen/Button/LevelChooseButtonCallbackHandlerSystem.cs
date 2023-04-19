using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI
{
    internal sealed class LevelChooseButtonCallbackHandlerSystem : IEcsRunSystem
    {
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
                SceneManager.LoadScene(_btnFilter.Get3(index).SceneName);
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
            }
        }
    }
}
