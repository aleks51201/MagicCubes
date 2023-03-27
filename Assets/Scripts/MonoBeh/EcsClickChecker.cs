using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MagicCubes.Cube
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
