using System;

/// <summary>
/// Default values here. Change if you need to
/// </summary>
[Serializable]
public class FingerCameraSettings
{
    /// <summary>
    /// Current distance of camera from tracked object
    /// </summary>
    public float DistanceOffset = 20;
    /// <summary>
    /// Current distance of camera window from chosen vertical edge
    /// </summary>
    public float VerticalInset = 5;
    /// <summary>
    /// Current distance of camera window from chosen horizonal edge
    /// </summary>
    public float HorizontalInset = 5;
    /// <summary>
    /// Current window size
    /// </summary>
    public float Size = 550;
}
