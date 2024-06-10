using UnityEngine;
using UnityEngine.EventSystems;

public class FingerCameraDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] FingerCameraBehaviour _fingerCameraBehaviour;
    public void OnDrag(PointerEventData eventData)
    {
        _fingerCameraBehaviour.ChangeWindowPosition(new Vector2(eventData.delta.x,eventData.delta.y));     
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        if (_fingerCameraBehaviour.UsePersistentSettings)
            FingerCameraSave.SaveFingerCameraSettings();
    }
}
