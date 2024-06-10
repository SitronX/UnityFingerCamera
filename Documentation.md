# Unity Finger camera documentation <sub>(ver 1.0)</sub>

Finger camera is easy to use, modular utility that you simply attach to any world object and the camera will follow the object from specified angle. All here mentioned scripts are residing in `FingerCamera/FingerCameraImplementation/Scripts`.


## Simplest usage

Locate **FingerCameraPrefab** in `FingerCamera/FingerCameraImplementation/Prefabs` and paste it to your scene.

Take reference of the `FingerCameraBehaviour.cs` and place it to your touch interaction script.

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/182ae5e6-d69e-4418-a9dc-43956c1d3847"/>

### Enabling camera

In the part of the code where you grab the object, simply call the main method

`StartFingerCamera(Transform trackedObject,Vector3 worldDirection,Vector3 worldUp=Vector3.up)`
- *Transform trackedObject* -> What transform should finger camera follow/be parented to
- *Vector3 worldDirection* -> From what direction should finger camera look on tracked object. Try what different directions suits you. For starters i recommend Vector.down for top-down view.
- *Vector3 worldUp* -> By default it is Vector3.up, but can be changed especially for different camera roll. Helpfull especially when camera direction is Vector.down

That is it, the finger camera will launch and follow the object from specified angle.

Note: `StartFingerCamera()` method can be called several times if you need to update any tracked parameters.

### Disabling camera
When you want to turn off finger camera (when user releases the grabbed object) just simply call method 

`StopFingerCamera()`

### Reseting camera

When something tragic happens (etc: user repositions the window outside of screen), method `ResetFingerCameraValues()` will reset window to use default values.

## Setting optionable parameters

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/a4510b9a-2810-474f-a37b-3a2f670f6e2f"/>

Here is a description of the main parameters which you can setup

- Use persistent settings ->Whether to save changes made on window during playtime. If checked, these parameters gets loaded automatically when game restarts. 

- MinWindowSize -> Minimal size that user can resize the window to

- MaxWindowSize -> Maximum size that user can resize the window to

- FingerCameraMinDistanceClamp -> How close can finger camera get to the tracked objects

- FingerCameraMaxDistanceClamp -> How far can finger camera get from the tracked objects

- FingerCameraZoomStep -> Intensity of zoom effect when user presses +/- buttons in window

- VerticalEdgeAnchor -> Choose the vertical edge, that the window gets anchored to

- HorizontalEdgeAnchor -> Choose the horizontal edge, that the window gets anchored to

## Setting default finger window parameters

 If you need to change parameters of which the finger camera is starting from, you can change values in `FingerCameraSettings.cs` script. 

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/0557bc06-e55b-4f93-9b64-efc899732aeb"/>

- Note: If you however use persistent settings, the next launch of the camera will continue from those saved settings. If you always want to start from your defined default values, uncheck the usage of persistent settings.

## Updating window in game mode

When the window is opened, several control buttons will appear. It can be resized, moved, zoomed in/out

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/01c2bfb9-e21c-47ee-9eb8-4ca8639424fb"/>

If you dont need some of the functionality provided, you can simply delete the controls from the prefab.

## Other properties and methods accessible in code

If in some case you need to control the finger window position/resize/zoom from code and not from user interface, it is possible. All available methods are in `FingerCameraBehaviour.cs` script.

### Properties
- `bool IsFingerCameraOn` - Whether the finger camera is on

### Methods
- `void SetInsets(float verticalInset, float horizontalInset, float size)` - You can manually set the finger camera window position/size.
    - *float verticalInset* -> The distance of the window from the chosen vertical edge of the screen
    - *float horizontalInset* -> The distance of the window from the chosen horizontal edge of the screen
    - *float size* -> Overall size of window
- `void ChangeWindowSize(float deltaChange)` - Increase/decrease the finger camera window size
    - *float deltaChange* -> Positive value will enlarge the window, negative will shrink it by the delta amount
- `void ChangeWindowPosition(Vector2 deltaChange)` - Move the finger camera window to another position 
    - *Vector2 deltaChange* -> Move already existing window by the x and y values on the sceen. The coordinate origin is in bottom left corner.

Note: All UI parameters are in pixel units.