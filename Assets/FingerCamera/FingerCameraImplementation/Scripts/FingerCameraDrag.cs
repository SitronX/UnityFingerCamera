using UnityEngine;
using UnityEngine.EventSystems;

public class FingerCameraDrag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [SerializeField] FingerCameraBehaviour _fingerCameraBehaviour;
    [SerializeField] InputHelper.TouchNumber _touchNumberToReact = InputHelper.TouchNumber.Last;

    public void OnDrag(PointerEventData eventData)
    {
        if (InputHelper.GetTouch(_touchNumberToReact, out Vector3 lastPos, out Vector2 touchDelta,out int inputCount))
            _fingerCameraBehaviour.ChangeWindowPosition(touchDelta);
        else
            _fingerCameraBehaviour.ChangeWindowPosition(new Vector2(eventData.delta.x, eventData.delta.y));  
    }

    public void OnEndDrag(PointerEventData eventData)
    {       
        if (_fingerCameraBehaviour.UsePersistentSettings)
            FingerCameraSave.SaveFingerCameraSettings();
    }
}
