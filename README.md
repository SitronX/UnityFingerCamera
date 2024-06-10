</p>
<p align="center">
  <img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/1378bcd9-e274-4101-b774-57d8fe801cee.png"/>
</p>

# UnityFingerCamera
Touch input on mobile devices has one major issue, user typically dont see what he is really doing on the screen, because he cannot see below his finger. This is especially problem when doing drag-drop operations on world objects. This plugin will help you mitigate that issue.

Finger camera is easy to use, modular utility that you simply attach to any world object and the camera will follow the object from specified angle.

This way user can actually see his actions on the object immediately.

Camera can be both be used in built in and URP render pipelines.

### chess showcase here

## How to install
You have two options how to install it into your project.

- First option is to download prepared Unity package in Github release section. After download, open your Unity project and simply open the downloaded package, import dialogue window should appear (Unity should automatically associate the package with itself). If it didnt work out for you, you can also import it thru Unity package manager.
- Second option is to download this sample project from Github and start using it, or just import the **FingerCamera** folder under `Assets/` into your project
    - Note: Unity versions 2019+ are officially supported

## Additional features

- Define finger window starting position
- Resize/reposition window during the play
- Zoom in/out of the tracked object
- Option to save window parameters, so user can modifiy it and it will remember parameters when he restarts the game.

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/01c2bfb9-e21c-47ee-9eb8-4ca8639424fb"/>

## How to use

- Detailed steps how to use FingerCamera are explained in the [documentation](Documentation.md)

## Example scene

Example scene showing basic interaction on chessboard is prepared. 

https://github.com/SitronX/UnityFingerCamera/assets/68167377/057fba89-8679-4094-992d-502b46e7e7c0

Example scene is primarily made for touch controls, but can also be controlled with mouse input. 
  - Left mouse click - grab the chess figure
  - Right mouse click - move/resize/zoom finger camera window.


Note: Example scene is set in built in render pipeline, if you want it to open in URP, simply upgrade the scene materials to URP and everything will work out fine.

## Real game showcase

- link to game

## Consider support

- link