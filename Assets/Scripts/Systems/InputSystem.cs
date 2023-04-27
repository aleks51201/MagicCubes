using Leopotam.Ecs;
using MagicCubes.Components;
using UnityEngine;

namespace MagicCubes.Systems.UI.GameScene
{
    public sealed class InputSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<InputComponent> _inputFilter = null;

        public void Init()
        {
            _world.NewEntity().Get<InputComponent>();
        }

        public void Run()
        {
            foreach (var index in _inputFilter)
            {
                _inputFilter.Get1(index).EscapeButtonDown = Input.GetKeyDown(KeyCode.Escape);
                _inputFilter.Get1(index).EscapeButtonUp = Input.GetKeyUp(KeyCode.Escape);
            }
        }
    }
}
