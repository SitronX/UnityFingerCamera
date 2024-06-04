using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FingerCameraEnlarge : MonoBehaviour, IDragHandler,IEndDragHandler
{
    [SerializeField] FingerCameraBehaviour _fingerCameraBehaviour;
    public void OnDrag(PointerEventData eventData)
    {
        _fingerCameraBehaviour.ChangeWindowSize(eventData.delta.y);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if(_fingerCameraBehaviour.UsePersistentSettings)
            FingerCameraSave.SaveFingerCameraSettings();
    }
}
