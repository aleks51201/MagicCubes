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
        private readonly EcsWorld _world;
        private readonly EcsFilter<RayCastComponent> _rayFilter;
        private readonly EcsFilter<CubeInitComponent> _cubeFilter;
        private readonly EcsFilter<NeighborsComponent, CubeInitComponent, ParticleComponent> _neighboorFilter;

        private const string Cube = "Cube";

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
                //if (!rayTransform.CompareTag(Cube)) break;
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
        private ParticleSystem[] Start(IEnumerable<Transform> transforms)
        {
            List<ParticleSystem> res = new();
            foreach (Transform transform in transforms)
            {
                res.Add(Start(transform));
            }
            return res.ToArray();
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

        private List<Transform> FindEqual(Transform currentCubeTransform, EcsFilter<NeighborsComponent, CubeInitComponent, ParticleComponent> filter)
        {
            List<Transform> res = new();
            foreach (var i in filter)
            {
                if (filter.Get2(i).cubeView.transform == currentCubeTransform)
                {
                    res.Add(currentCubeTransform);
                    foreach (var neighbor in filter.Get1(i).neighborsCubes)
                    {
                        res.Add(neighbor.transform);
                    }
                }
            }
            return res;
        }

        private bool IsEqual(List<Transform> transforms, List<ParticleSystem> particles)
        {
            if (transforms.Count != particles.Count) return false;
            for (int i = 0; i < transforms.Count; i++)
            {
                if (GetParticleSystem(transforms[i]) == particles[i]) return false;
            }
            return true;
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
