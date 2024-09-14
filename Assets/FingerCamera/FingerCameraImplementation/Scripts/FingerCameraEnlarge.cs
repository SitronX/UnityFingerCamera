using UnityEngine;
using UnityEngine.EventSystems;

public class FingerCameraEnlarge : MonoBehaviour, IDragHandler,IEndDragHandler
{
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] FingerCameraBehaviour _fingerCameraBehaviour;
    [SerializeField] InputHelper.TouchNumber _touchNumberToReact = InputHelper.TouchNumber.Last;

    private void Awake()
    {
        ChangeOrientationBasedOnEdge(_fingerCameraBehaviour.GetRectEdge(_fingerCameraBehaviour.VerticalEdgeAnchor));
        _fingerCameraBehaviour.VerticalEdgeAnchorChanged += (RectTransform.Edge edge) => ChangeOrientationBasedOnEdge(edge);       
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (InputHelper.GetTouch(_touchNumberToReact, out Vector3 lastPos, out Vector2 touchDelta,out int inputCount))
            _fingerCameraBehaviour.ChangeWindowSize(touchDelta.y);
        else
            _fingerCameraBehaviour.ChangeWindowSize(eventData.delta.y);
    }
    public void ChangeOrientationBasedOnEdge(RectTransform.Edge edge)
    {
        _rectTransform.SetInsetAndSizeFromParentEdge(edge==RectTransform.Edge.Top?RectTransform.Edge.Bottom:RectTransform.Edge.Top, -15, 80);  //Enlarging handle always on the opposite vertical edge
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        if(_fingerCameraBehaviour.UsePersistentSettings)
            FingerCameraSave.SaveFingerCameraSettings();
    }
}
