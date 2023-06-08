using MagicCubes.Events.Ui;
using MagicCubes.Systems.UI;
using MagicCubes.Systems.UI.MenuScene;
using MagicCubes.Systems.UI.Save;

namespace MagicCubes
{
    public class MenuSceneEcsStartup : EcsStartupBase
    {
        private protected override void AddInjections()
        {
            base.AddInjections();
        }

        private protected override void AddOneFrames()
        {
            _systems
                .OneFrame<StartButtonClickedEvent>();
        }

        private protected override void AddSystems()
        {
            _systems
                .Add(new CreateEntityForUIVisualElementSystem())

                .Add(new InitSavesSystem())
                .Add(new LoadSystem())

                .Add(new StartButtonRegisterCallbackSystem())
                .Add(new StartButtonClickHandlerSystem())
                .Add(new lvlChooseScreenInitStartSystem())
                .Add(new LevelChooseButtonRegisterCallbackSystem())
                .Add(new LevelChooseButtonCallbackHandlerSystem());
        }
    }
}
