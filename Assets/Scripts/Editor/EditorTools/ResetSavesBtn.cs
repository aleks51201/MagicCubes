using UnityEngine;
using UnityEngine.EventSystems;

namespace MagicCubes.EditTool
{
    public class ResetSavesBtn : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
