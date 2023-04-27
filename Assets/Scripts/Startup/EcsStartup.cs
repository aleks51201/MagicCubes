using MagicCubes.Events;
using MagicCubes.Events.Ui;
using MagicCubes.Systems;
using MagicCubes.Systems.UI;

namespace MagicCubes
{
    public class EcsStartup : EcsStartupBase
    {
        private protected override void AddInjections()
        {
            base.AddInjections();
            _systems
                .Inject(_configurations);
        }

        private protected override void AddOneFrames()
        {
            _systems
                .OneFrame<WinEvent>()
                .OneFrame<StartButtonClickedEvent>();
        }

        private protected override void AddSystems()
        {
            _systems
                // .Add(new SceneConfigValidatorSystem())
                .Add(new CreateEntityForUIVisualElementSystem())
                .Add(new StartButtonRegisterCallbackSystem())
                .Add(new StartButtonClickHandlerSystem())
                .Add(new lvlChooseScreenInitStartSystem())
                .Add(new LevelChooseButtonRegisterCallbackSystem())
                .Add(new LevelChooseButtonCallbackHandlerSystem())
                .Add(new CreateEntityForCubeViewSystem())
                .Add(new RotationSystem())
                .Add(new WinRotationCheckSystem())
                .Add(new WinSystem());
        }
    }
}
