using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.SceneManagement;

namespace MagicCubes.Systems.UI
{
    internal sealed class ResetButtonCallbackHandlerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ResetButtonClickEvent, ResetButtonComponent> _btnFilter = null;


        public void Run()
        {
            foreach (var index in _btnFilter)
            {
                _btnFilter.GetEntity(index).Del<ResumeButtonClickEvent>();
                if (!_btnFilter.Get2(index).ButtonStatusHolder.IsClicked)
                {
                    continue;
                }
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.UnloadSceneAsync(scene.name);
                SceneManager.LoadScene(scene.name);
                _btnFilter.Get2(index).ButtonStatusHolder.StatusReset();
            }
        }
    }
}
