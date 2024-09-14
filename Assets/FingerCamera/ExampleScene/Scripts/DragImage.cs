using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Showcase how to use finger camera in UI stuff
public class DragImage : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler
{
    [field:SerializeField] public Text TextUI { get; set; }
    [SerializeField] FingerCameraBehaviour _fingerCamera;
    public void OnBeginDrag(PointerEventData eventData)
    {
        _fingerCamera.StartFingerCamera(transform, Vector3.forward);
    }

    public void OnDrag(PointerEventData eventData)
    {
        List<RaycastResult> hitResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, hitResults);

        RaycastResult target = hitResults.FirstOrDefault(x => x.gameObject != this.gameObject && x.gameObject.layer==10);
        if (target.gameObject != null)
        {
            int targetIndex = target.gameObject.transform.GetSiblingIndex();
            transform.parent = target.gameObject.transform.parent;
            transform.SetSiblingIndex(targetIndex);
        }
        else
        {
            Vector3 lastPos;
            if (Input.touchCount > 0)
                lastPos = Input.GetTouch(0).position;
            else
                lastPos = Input.mousePosition;

            lastPos.z = 1;
            transform.position = Camera.main.ScreenToWorldPoint(lastPos);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform.parent.GetComponent<RectTransform>());
        _fingerCamera.StopFingerCamera();
    }
}
