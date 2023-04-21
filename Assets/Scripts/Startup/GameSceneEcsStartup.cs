using MagicCubes.Events.Ui;
using MagicCubes.Systems;
using MagicCubes.Systems.UI;
using MagicCubes.Systems.UI.GameScene;

namespace MagicCubes
{
    public class GameSceneEcsStartup : EcsStartupBase
    {
        private protected override void AddInjections()
        {
            base.AddInjections();
        }

        private protected override void AddOneFrames()
        {
            _systems
                .OneFrame<OpenedPauseMenuEvent>();
        }

        private protected override void AddSystems()
        {
            _systems
                .Add(new InitGameSceneUISystem())
                .Add(new CreateEntityForCubeViewSystem())
                .Add(new InputSystem())
                .Add(new OpenPauseMenuSystem())
                .Add(new BackToMenuRegisterCallBackSystem())
                .Add(new BackToMenuButtonCallbackHandlerSystem())
                .Add(new ResetRegisterCallBackSystem())
                .Add(new ResetButtonCallbackHandlerSystem())
                .Add(new ResumeButtonRegisterCallBackSystem())
                .Add(new ResumeButtonCallbackHandlerSystem())
                .Add(new ScoringSystem())
                .Add(new RotationSystem())
                .Add(new WinRotationCheckSystem())
                .Add(new WinSystem());
        }
    }
}
