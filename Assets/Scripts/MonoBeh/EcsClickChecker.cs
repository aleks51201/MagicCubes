using Leopotam.Ecs;
using MagicCubes.Events;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MagicCubes.MonoBeh
{
    public class EcsClickChecker : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CubeView _cubeView;


        public void OnPointerClick(PointerEventData eventData)
        {
            var ent = _cubeView.ecsEntity;

            _cubeView.ecsEntity.Get<RotateEvent>();
        }
    }
}
