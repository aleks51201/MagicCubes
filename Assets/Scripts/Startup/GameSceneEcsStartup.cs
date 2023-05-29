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
                .OneFrame<WinEvent>()
                .OneFrame<ClosedPauseMenuEvent>()
                .OneFrame<ClosedWinMenuEvent>();
        }

        private protected override void AddSystems()
        {
            _systems
                .Add(new InitGameSceneUISystem())
                .Add(new LvlInitSystem())
                .Add(new CreateEntityForCubeViewSystem())
                .Add(new InputSystem())
                .Add(new ScoringSystem())
                .Add(new ProgressBarSystem())
                .Add(new ProgressStarSystem())
                .Add(new RotationSystem())
                .Add(new WinRotationCheckSystem())

                .Add(new PauseMenuSystem())
                .Add(new OpenWinPanelSystem())

                .Add(new FilStarSystem())

                .Add(new BackToMenuRegisterCallBackSystem())
                .Add(new ResumeButtonRegisterCallBackSystem())
                .Add(new ResetRegisterCallBackSystem())
                .Add(new NextLvlButtonRegisterCallBackSystem())

                .Add(new BackToMenuButtonCallbackHandlerSystem())
                .Add(new ResumeButtonCallbackHandlerSystem())
                .Add(new ResetButtonCallbackHandlerSystem())
                .Add(new NextLvlButtonCallbackHandlerSystem())

                .Add(new CloseWinPanelSystem())

                .Add(new BackToMenuUnregisterCallBackSystem())
                .Add(new ResumeButtonUnregisterCallBackSystem())
                .Add(new ResetUnregisterCallBackSystem())
                .Add(new NextLvlButtonUnregisterCallBackSystem());
        }
    }
}
