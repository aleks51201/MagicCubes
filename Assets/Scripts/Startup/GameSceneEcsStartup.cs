using MagicCubes.Systems;
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
        }

        private protected override void AddSystems()
        {
            _systems
                .Add(new InitGameSceneUISystem())
                .Add(new CreateEntityForCubeViewSystem())
                .Add(new InputSystem())
                .Add(new OpenPauseMenuSystem())
                .Add(new ScoringSystem())
                .Add(new RotationSystem())
                .Add(new WinRotationCheckSystem())
                .Add(new WinSystem());
        }
    }
}
