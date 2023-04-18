using Leopotam.Ecs;

namespace MagicCubes.Cube
{
    sealed class CreateEntityForCubeViewSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CubeInitComponent> _initFilter = null;
        //private CubeView[] _cubeViews = null;


        public void Init()
        {
            /*            foreach (CubeView cubeView in _cubeViews)
                        {
                            var entity = _world.NewEntity();
                            entity.Get<CubeTag>();
                            entity.Get<EntityCubeViewComponent>().cubeView = cubeView;
                            cubeView.ecsEntity = entity;
                        }
            */
            foreach (var item in _initFilter)
            {
                ref var init = ref _initFilter.Get1(item);
                var cubeView = init.cubeView;
                ref var entity = ref _initFilter.GetEntity(item);
                entity.Get<CubeTag>();

                cubeView.ecsEntity = entity;
            }
        }
    }
}
