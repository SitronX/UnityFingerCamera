# Unity Finger camera documentation <sub>(ver 1.0)</sub>

Finger camera is easy-to-use, modular utility that you can attach to any world object and the camera will follow the object from a specified angle. All the scripts mentioned here are located in `FingerCamera/FingerCameraImplementation/Scripts`.


## Simplest usage

Locate **FingerCameraPrefab** in `FingerCamera/FingerCameraImplementation/Prefabs` and add it to your scene.

Incorporate the reference of `FingerCameraBehaviour.cs` into your touch interaction script (following methods will be called on this script).

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/182ae5e6-d69e-4418-a9dc-43956c1d3847"/>


### Enabling camera

In the part of the code where you grab the object, simply call the main method:

`StartFingerCamera(Transform trackedObject,Vector3 cameraNormalizedDirection,Vector3 worldUp=Vector3.up)`
- *Transform trackedObject*: The transform that the finger camera should follow and be parented to.
- *Vector3 cameraNormalizedDirection*: The normalized direction from which the finger camera should look at the tracked object. Experiment with different directions to see what suits your needs. For starters, I recommend `Vector3.down` for a top-down view.
- *Vector3 worldUp*: By default, this is `Vector3.up`, but it can be changed, especially for different camera rolls. This is particularly useful when the camera direction is `Vector3.down`.

That's it! The finger camera will launch and follow the object from the specified angle.

**Note:** The `StartFingerCamera()` method can be called several times if you need to update any tracked parameters.

### Disabling camera
When you want to turn off finger camera (when user releases the grabbed object), simply call the method:

`StopFingerCamera()`

### Reseting camera

If something goes wrong (e.g., the user repositions the window outside of the screen), the method `ResetFingerCameraValues()` will reset the window to its default values.

## Setting optionable parameters

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/f55380b3-e6b0-4102-b479-71618cc05aed"/>

Here is a description of the main parameters you can set up:

- *Use persistent settings:* Whether to save changes made to the window during playtime. If checked, these parameters get loaded automatically when the game restarts.

- *MinWindowSize:* The minimum size to which the user can resize the window.

- *MaxWindowSize:* The maximum size to which the user can resize the window.

- *VerticalEdgeAnchor:* Choose the vertical edge to which the window is anchored. The resizing handle location and behavior depend on this edge.

- *HorizontalEdgeAnchor:* Choose the horizontal edge to which the window is anchored. The resizing behavior depends on this edge.

- *FingerCameraMinDistanceClamp:* How close the finger camera can get to the tracked objects.

- *FingerCameraMaxDistanceClamp:* How far the finger camera can get from the tracked objects.

- *FingerCameraZoomStep:* The intensity of the zoom effect when the user presses the +/- buttons in the window.

**Note:** Starting from version 1.1, the properties *VerticalEdgeAnchor* and *HorizontalEdgeAnchor* also have the option of autoedge. When autoedge is selected, the edge is automatically set to the opposite side of the finger's position on the screen.

## Setting default finger window parameters

If you need to change the default parameters from which the finger camera starts, you can change the values in the `FingerCameraSettings.cs` script. 

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/0557bc06-e55b-4f93-9b64-efc899732aeb"/>

**Note:** If you use persistent settings, the next launch of the camera will continue from those saved settings. If you always want to start from your defined default values, uncheck the usage of persistent settings.

## Updating the window in game mode

When the window is opened, several control buttons will appear. It can be resized, moved, and zoomed in/out

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/01c2bfb9-e21c-47ee-9eb8-4ca8639424fb"/>

If you don't need some of the functionality provided, you can simply delete the controls from the prefab.

**Note:** Don't forget to have an EventSystem present in the scene when interacting with the canvas buttons, otherwise controls won't work.

## Other properties and methods accessible in code

If you need to control the finger window position/resize/zoom from code instead of the user interface, it is possible. All available methods are in the `FingerCameraBehaviour.cs` script.

### Properties
- `bool IsFingerCameraOn`: Indicates whether the finger camera is on.

### Methods
- `void SetInsets(float verticalInset, float horizontalInset, float size)`: Manually set the finger camera window position and size.
    - *float verticalInset:* The distance of the window from the chosen vertical edge of the screen.
    - *float horizontalInset:* The distance of the window from the chosen horizontal edge of the screen.
    - *float size:* The overall size of the window.
- `void ChangeWindowSize(float deltaChange)`: Increase or decrease the finger camera window size.
    - *float deltaChange:* A positive value will enlarge the window, while a negative value will shrink it by the delta amount.
- `void ChangeWindowPosition(Vector2 deltaChange)`: Move the finger camera window to another position.
    - *Vector2 deltaChange:* Move the existing window by the x and y values on the screen. The coordinate origin is in the bottom left corner.

**Note:** All UI parameters are in pixel units.
