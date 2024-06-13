using UnityEngine;
using UnityEngine.EventSystems;
using static FingerCameraBehaviour;

public class FingerCameraEnlarge : MonoBehaviour, IDragHandler,IEndDragHandler
{
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] FingerCameraBehaviour _fingerCameraBehaviour;

    private void Start()
    {
        ChangeOrientationBasedOnEdge(_fingerCameraBehaviour.VerticalEdgeAnchor);
    }
    public void OnDrag(PointerEventData eventData)
    {
        _fingerCameraBehaviour.ChangeWindowSize(eventData.delta.y);
    }
    public void ChangeOrientationBasedOnEdge(VerticalEdge edge)
    {
        _rectTransform.SetInsetAndSizeFromParentEdge(edge == VerticalEdge.Top? RectTransform.Edge.Bottom:RectTransform.Edge.Top, -15, 80);  //Enlarging handle always on the opposite vertical edge
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if(_fingerCameraBehaviour.UsePersistentSettings)
            FingerCameraSave.SaveFingerCameraSettings();
    }
}
