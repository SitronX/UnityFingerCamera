</p>
<p align="center">
  <img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/b7beb545-99f5-470c-92be-368974e0068c" width=256/>
</p>

# UnityFingerCamera
Touch input on mobile devices has one major issue, user typically dont see what he is really doing on the screen, because he cannot see below his finger. This is especially problem when doing drag-drop operations on world objects. This plugin will help you mitigate that issue.

Finger camera is easy to use, modular utility that you simply attach to any world object and the camera will follow the object from specified angle.

This way user can actually see his actions on the object immediately.


https://github.com/SitronX/UnityFingerCamera/assets/68167377/a584d365-fb17-4b15-a808-cc0eb90f889f



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

Here is a showcase of this asset in real game.

https://github.com/SitronX/UnityFingerCamera/assets/68167377/03646891-aea1-494d-9bd9-8b01431ac8d7

The game was main propelent to relase this asset. You can download it free on [Google Play](https://play.google.com/store/apps/details?id=com.SitronCOR.Forcel)

Thanx to community support, this is a second feature "gutted" from the game and made open for community. If curious, you can find the first repository [here](https://github.com/SitronX/UnityTimeRewinder).

## License

This plugin is completely free with [MIT license](https://github.com/SitronX/UnityFingerCamera?tab=MIT-1-ov-file#readme),  you can freely use as you wish :) 

If you really like my projects, please consider buying me a coffee to support my work. All donations will be greatly appreaciated :)

[![BuyMeACoffe](https://github.com/SitronX/UnityFingerCamera/assets/68167377/6559a423-bf31-4c14-96a5-10c0a907944f)](https://buymeacoffee.com/sitronx)
