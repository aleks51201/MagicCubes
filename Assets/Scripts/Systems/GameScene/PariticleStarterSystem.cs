using Leopotam.Ecs;
using MagicCubes.Components;
using MagicCubes.Components.GameScene;
using MagicCubes.MonoBeh;
using System.Collections.Generic;
using UnityEngine;

namespace MagicCubes.Systems.GameScene
{
    public class PariticleStarterSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsFilter<RayCastComponent> _rayFilter;
        private readonly EcsFilter<CubeInitComponent> _cubeFilter;
        private readonly EcsFilter<NeighborsComponent, CubeInitComponent, ParticleComponent> _neighboorFilter;


        public void Init()
        {
            foreach (var i in _cubeFilter)
            {
                _cubeFilter.GetEntity(i).Get<ParticleComponent>().CurrentParticleSystem = new();
            }
        }

        public void Run()
        {
            foreach (var i in _rayFilter)
            {
                Transform rayTransform = _rayFilter.Get1(i).RaycastHit.transform;
                foreach (var j in _neighboorFilter)
                {
                    Transform cubeTransform = _neighboorFilter.Get2(j).cubeView.transform;
                    List<Transform> transforms = GetNeighboors(j);
                    transforms.Add(cubeTransform);
                    List<ParticleSystem> particles = _neighboorFilter.Get3(j).CurrentParticleSystem;
                    List<ParticleSystem> newParticles = new();
                    if (IsEqual(rayTransform, cubeTransform))
                    {
                        if (particles.Count != 0) continue;
                        newParticles = Start(transforms);
                        _neighboorFilter.Get3(j).CurrentParticleSystem = newParticles;
                    }
                    else
                    {
                        if (particles.Count == 0) continue;
                        Stop(particles);
                        _neighboorFilter.Get3(j).CurrentParticleSystem = new();
                    }
                }
            }
        }

        private List<ParticleSystem> Start(List<Transform> transforms)
        {
            List<ParticleSystem> newParticles = new();
            foreach (Transform transform in transforms)
            {
                var newParticle = Start(transform);
                newParticles.Add(newParticle);
            }
            return newParticles;
        }

        private ParticleSystem Start(Transform transform)
        {
            ParticleSystem res = GetParticleSystem(transform);
            res.Play();
            return res;
        }

        private void Stop(ParticleSystem particleSystem)
        {
            if (particleSystem == null) return;
            if (particleSystem.isPlaying)
                particleSystem.Stop();
        }

        private void Stop(List<ParticleSystem> particles)
        {
            foreach (ParticleSystem particle in particles)
            {
                Stop(particle);
            }
        }

        private ParticleSystem GetParticleSystem(Transform transform)
        {
            return transform.GetComponentInChildren<ParticleSystem>();
        }

        private bool IsEqual(Transform first, Transform second)
        {
            return first == second;
        }

        private List<Transform> GetNeighboors(int index)
        {
            List<Transform> res = new();
            foreach (CubeView neighbor in _neighboorFilter.Get1(index).neighborsCubes)
            {
                res.Add(neighbor.transform);
            }
            return res;
        }
    }
}
