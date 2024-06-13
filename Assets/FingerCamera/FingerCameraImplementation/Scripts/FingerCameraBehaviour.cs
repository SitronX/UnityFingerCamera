using System.Collections;
using UnityEngine;

public class FingerCameraBehaviour : MonoBehaviour
{
    /// <summary>
    /// Whether the finger camera is on
    /// </summary>
    public bool IsFingerCameraOn { get; private set; }
    
    /// <summary>
    /// Whether to save finger camera settings so it loads when game restarts
    /// </summary>
    [field: Tooltip("Whether to save finger camera settings so it loads when game restarts")]
    [field: SerializeField] public bool UsePersistentSettings { get; set; } = true;
    
    /// <summary>
    /// Minimum size of finger camera window
    /// </summary>
    [field: Tooltip("Minimum size of finger camera window")]
    [field: SerializeField] public float MinWindowSize { get; set; } = 300;
    
    /// <summary>
    /// Maximum size of finger camera window
    /// </summary>
    [field: Tooltip("Maximum size of finger camera window")]
    [field: SerializeField] public float MaxWindowSize { get; set; } = 900;

    /// <summary>
    /// Do we want to defaultly anchor finger camera window on top or bottom?
    /// </summary>
    [field: Tooltip("Do we want to defaultly anchor finger camera window on top or bottom?")]
    [field: SerializeField] public VerticalEdge VerticalEdgeAnchor { get; private set; } = VerticalEdge.Top;

    /// <summary>
    /// Do we want to defaultly anchor finger camera window on left or right ?
    /// </summary>
    [field: Tooltip("Do we want to defaultly anchor finger camera window on left or right ?")]
    [field: SerializeField] public HorizontalEdge HorizontalEdgeAnchor { get; private set; } = HorizontalEdge.Left;

    /// <summary>
    /// How close can finger camera get to the tracked objects
    /// </summary>
    [field: Tooltip("How close can finger camera get to the tracked objects")]
    [SerializeField] float _fingerCameraMinDistanceClamp = 5;

    /// <summary>
    /// How far can finger camera get from the tracked objects
    /// </summary>
    [field: Tooltip("How far can finger camera get from the tracked objects")]
    [SerializeField] float _fingerCameraMaxDistanceClamp = 70;

    /// <summary>
    /// Intensity of zoom effect when +/- buttons are pressed in window
    /// </summary>
    [field: Tooltip("Intensity of zoom effect when +/- buttons are pressed in window")]
    [SerializeField] float _fingerCameraZoomStep = 1;
   
    [SerializeField] Camera _camera;
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] RenderTexture _renderTexture;
    [SerializeField] Canvas _canvas;

    Coroutine _cameraMoveCoroutine;
    Animator _animator;
    Vector3 _normalizedWorldDirection;
   
    /// <summary>
    /// Resets finger camera & window to default values
    /// </summary>
    public void ResetFingerCameraValues()
    {
        FingerCameraSave.CameraSettings = new FingerCameraSettings();
        FingerCameraSave.SaveFingerCameraSettings();
        SetInsets(FingerCameraSave.CameraSettings.VerticalInset, FingerCameraSave.CameraSettings.HorizontalInset, FingerCameraSave.CameraSettings.Size);
        SetFingerCamera();
    }
    /// <summary>
    /// You can manually set the finger camera window position/size.
    /// </summary>
    /// <param name="verticalInset">The distance from the chosen vertical edge of the screen</param>
    /// <param name="horizontalInset">The distance from the chosen horizontal edge of the screen</param>
    /// <param name="size">Overall size of window</param>
    public void SetInsets(float verticalInset, float horizontalInset, float size)
    {
        _rectTransform.SetInsetAndSizeFromParentEdge(GetRectEdge(VerticalEdgeAnchor), verticalInset, size);
        _rectTransform.SetInsetAndSizeFromParentEdge(GetRectEdge(HorizontalEdgeAnchor), horizontalInset, size);

        _renderTexture.Release();
        _renderTexture.width = (int)(_rectTransform.sizeDelta.y * Screen.height * 0.001f);
        _renderTexture.height = (int)(_rectTransform.sizeDelta.y * Screen.height * 0.001f);

        FingerCameraSave.CameraSettings.HorizontalInset = horizontalInset;
        FingerCameraSave.CameraSettings.VerticalInset = verticalInset;
        FingerCameraSave.CameraSettings.Size = size;
    }
    /// <summary>
    /// You can manually increase/decrease the finger camera window size
    /// </summary>
    /// <param name="deltaChange">Positive value will enlarge the window, negative will shrink it by the set amount</param>
    public void ChangeWindowSize(float deltaChange)
    {
        float recommendedSize = (_rectTransform.sizeDelta.y + RealToInset(deltaChange / _canvas.scaleFactor));
        float newClampedSize = ClampSize(recommendedSize);
        SetInsets(FingerCameraSave.CameraSettings.VerticalInset, FingerCameraSave.CameraSettings.HorizontalInset, newClampedSize);
    }
    /// <summary>
    /// You can manually move the finger camera window to another position
    /// </summary>
    /// <param name="deltaChange">It will move already existing window by the x and y values. The origin is in bottom left corner (positive X right, positive Y up).</param>
    public void ChangeWindowPosition(Vector2 deltaChange)
    {
        Vector2 scaledDeltaChange = RealToInset(deltaChange / _canvas.scaleFactor);
        SetInsets(FingerCameraSave.CameraSettings.VerticalInset+ scaledDeltaChange.y, FingerCameraSave.CameraSettings.HorizontalInset+ scaledDeltaChange.x, FingerCameraSave.CameraSettings.Size);
    }
    /// <summary>
    /// Main method to start finger camera. Can be called even when it already started to refresh values
    /// </summary>
    /// <param name="trackedObject">What transform should finger camera follow/be parented to</param>
    /// <param name="worldDirection">From what direction should finger camera look on tracked object. Try what different directions suits you, for starters i recommed Vector.down</param>
    /// <param name="worldUp">Define up parameter. Usually it is Vector.up, but can be changed especially for different camera roll. Helpfull especially when camera direction is Vector.down</param>
    public void StartFingerCamera(Transform trackedObject,Vector3 worldDirection,Vector3 worldUp)
    {
        _normalizedWorldDirection = worldDirection.normalized;
        
        _camera.transform.parent = trackedObject;
        SetFingerCamera();
        _camera.transform.LookAt(trackedObject, worldUp); 

        IsFingerCameraOn = true;
        _animator.SetBool("CameraAppear", true);
    }
    /// <summary>
    /// Main method to start finger camera. Can be called even when it already started to refresh values
    /// </summary>
    /// <param name="trackedObject">What transform should finger camera follow/be parented to</param>
    /// <param name="worldDirection">From what direction should finger camera look on tracked object. Try what different directions suits you, for starters i recommed Vector.down</param>
    public void StartFingerCamera(Transform trackedObject, Vector3 worldDirection)
    {
        StartFingerCamera(trackedObject, worldDirection, Vector3.up);
    }
    /// <summary>
    /// Main method to stop finger camera
    /// </summary>
    public void StopFingerCamera()
    {
       if (IsFingerCameraOn)
       {
           _camera.transform.parent = transform;
           IsFingerCameraOn = false;
            _animator.SetBool("CameraAppear", false);
        }
    }

    public enum HorizontalEdge
    {
        Left, Right
    }
    public enum VerticalEdge
    {
        Bottom, Top
    }
    #region InternalMethods

    RectTransform.Edge GetRectEdge(HorizontalEdge edge)
    {
        if (edge == HorizontalEdge.Right)
            return RectTransform.Edge.Right;
        else
            return RectTransform.Edge.Left;
    }
    RectTransform.Edge GetRectEdge(VerticalEdge edge)
    {
        if (edge == VerticalEdge.Bottom)
            return RectTransform.Edge.Bottom;
        else
            return RectTransform.Edge.Top;
    }
    float ClampSize(float size)
    {
        return Mathf.Min(MaxWindowSize, Mathf.Max(MinWindowSize, size));
    }
    Vector2 RealToInset(Vector2 realMove)
    {
        if(VerticalEdgeAnchor==VerticalEdge.Top)
            realMove.y=-realMove.y;
        if(HorizontalEdgeAnchor==HorizontalEdge.Right)
            realMove.x=-realMove.x;

        return realMove;
    }
    float RealToInset(float realMove)
    {
        return VerticalEdgeAnchor == VerticalEdge.Top? -realMove:realMove;
    }
    void MoveFingerCamera(float moveValue)
    {
        float value = Mathf.Max(_fingerCameraMinDistanceClamp, Mathf.Min(FingerCameraSave.CameraSettings.DistanceOffset + moveValue, _fingerCameraMaxDistanceClamp));

        FingerCameraSave.CameraSettings.DistanceOffset = value;
        SetFingerCamera();
    }
    private void Awake()
    {
        FingerCameraSave.LoadFingerCameraSettings(UsePersistentSettings);

        _animator = GetComponent<Animator>();
        SetInsets(FingerCameraSave.CameraSettings.VerticalInset, FingerCameraSave.CameraSettings.HorizontalInset, FingerCameraSave.CameraSettings.Size);

    }
    void ButtonDown(float value)
    {
        _cameraMoveCoroutine = StartCoroutine(CameraMove(value * _fingerCameraZoomStep));
    }
    void ButtonUp()
    {
        StopCoroutine(_cameraMoveCoroutine);

        if (UsePersistentSettings)
        {
            FingerCameraSave.SaveFingerCameraSettings();
            SetFingerCamera();
        }
    }
    IEnumerator CameraMove(float moveDirection)
    {
        while (true)
        {
            MoveFingerCamera(moveDirection);
            yield return new WaitForSeconds(0.02f);
        }
    }
    void SetFingerCamera()
    {
        _camera.transform.position = _camera.transform.parent.position - (_normalizedWorldDirection * FingerCameraSave.CameraSettings.DistanceOffset);
    }
    #endregion
}
