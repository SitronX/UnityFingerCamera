using System;
using System.Collections.Generic;
using UnityEngine;


public class TouchControl : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] FingerCameraBehaviour _fingerCamera;

    PlaceablePosition _initialPos;
    PlaceablePosition _lastHoverPosition;
    int _fingerCameraMode = 0;
    Dictionary<Collider,PlaceablePosition> _placeablePositions=new Dictionary<Collider,PlaceablePosition>();

    List<Tuple<Vector3, Quaternion>> _mainCameraPositions = new List<Tuple<Vector3, Quaternion>>()
    {
        new Tuple<Vector3, Quaternion>(new Vector3(-0.5f, 10, -4), Quaternion.Euler(new Vector3(60, 0, 0))),
        new Tuple<Vector3, Quaternion>(new Vector3(-6, 9, 2f), Quaternion.Euler(new Vector3(60, 90, 0)))
    };

    private void Start()
    {
        foreach (PlaceablePosition i in FindObjectsOfType<PlaceablePosition>())
            _placeablePositions.Add(i.GetComponent<Collider>(), i);
    }
    public void ChangeMainCameraPos(int posIndex)
    {
        var pos = _mainCameraPositions[posIndex];
        _camera.transform.position = pos.Item1;
        _camera.transform.rotation = pos.Item2;

        if (_fingerCamera.IsFingerCameraOn)
            StartFingerCamera();                //Refresh if it is already on
    }
    public void SetFingerCameraMode(int mode)
    { 
        _fingerCameraMode = mode;

        if (_fingerCamera.IsFingerCameraOn)
            StartFingerCamera();                //Refresh if it is already on
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (_initialPos==null)
            {
                if (Physics.Raycast(ray, out RaycastHit info, 300, 1 << 9))
                {
                    if(_placeablePositions[info.collider].Figure != null)
                    {
                        _initialPos = _placeablePositions[info.collider];
                        StartFingerCamera();
                    }
                }
            }
            else if(Input.touchCount<=1)    //If we use touch, on camera manipulation, without this check, it would mess up controls
            {
                if (Physics.Raycast(ray, out RaycastHit info, 300, 1 << 9|1<<0))
                {
                    _initialPos.Figure.position = info.point + (Vector3.up * 0.2f);

                    if (_placeablePositions.ContainsKey(info.collider))
                    {
                        foreach (PlaceablePosition item in _placeablePositions.Values)
                            item.ClearHighlight();

                        _lastHoverPosition = _placeablePositions[info.collider];
                        _lastHoverPosition.SetHighlightColor(_lastHoverPosition.Figure == null ? Color.green : Color.red);
                    }
                }
            }
        }
        else if(_initialPos != null)
        {
            _lastHoverPosition.ClearHighlight();

            if (_lastHoverPosition.Figure == null)
            {
                _lastHoverPosition.Figure = _initialPos.Figure;
                _lastHoverPosition.PlaceFigureIntoPosition(_initialPos.Figure);
                _initialPos.Figure = null;
            }
            else
                _initialPos.PlaceFigureIntoPosition(_initialPos.Figure);

            _initialPos = null;
            _fingerCamera.StopFingerCamera();
        }
    }
    void StartFingerCamera()
    {
        if(_fingerCameraMode == 0)
            _fingerCamera.StartFingerCamera(_initialPos.Figure, Vector3.down, Vector3.forward);
        else if(_fingerCameraMode == 1)
            _fingerCamera.StartFingerCamera(_initialPos.Figure, Vector3.down, Vector3.right);
        else
            _fingerCamera.StartFingerCamera(_initialPos.Figure, _camera.transform.forward,Vector3.up);
    }

}
