using Leopotam.Ecs;
using MagicCubes.Components.Ui;
using MagicCubes.Events.Ui;
using UnityEngine.UIElements;

namespace MagicCubes.Systems.UI
{
    public class StartButtonRegisterCallbackSystem : IEcsInitSystem
    {
        private readonly EcsFilter<StartButtonComponent> _startButtonFilter = null;


        public void Init()
        {
            foreach (var index in _startButtonFilter)
            {
                _startButtonFilter.Get1(0).Button.RegisterCallback<ClickEvent>(OnButtonClick);
            }
        }

        private void OnButtonClick(ClickEvent clickEvent)
        {
            foreach (var index in _startButtonFilter)
            {
                _startButtonFilter.GetEntity(index).Get<StartButtonClickEvent>();
            }
        }
    }
}
