using MagicCubes.Events;
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
                .OneFrame<OpenedPauseMenuEvent>()
                .OneFrame<OpenedWinMenuEvent>()
                .OneFrame<WinEvent>();
        }

        private protected override void AddSystems()
        {
            _systems
                .Add(new InitGameSceneUISystem())
                .Add(new CreateEntityForCubeViewSystem())
                .Add(new InputSystem())
                .Add(new ScoringSystem())
                .Add(new RotationSystem())
                .Add(new WinRotationCheckSystem())
                .Add(new WinSystem())
                .Add(new OpenPauseMenuSystem())
                .Add(new BackToMenuRegisterCallBackSystem())
                .Add(new BackToMenuButtonCallbackHandlerSystem())
                .Add(new ResetRegisterCallBackSystem())
                .Add(new ResetButtonCallbackHandlerSystem())
                .Add(new ResumeButtonRegisterCallBackSystem())
                .Add(new ResumeButtonCallbackHandlerSystem())
                .Add(new NextLvlButtonRegisterCallBackSystem())
                .Add(new NextLvlButtonCallbackHandlerSystem());
        }
    }
}
