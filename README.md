</p>
<p align="center">
  <img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/b7beb545-99f5-470c-92be-368974e0068c" width=256/>
</p>

# UnityFingerCamera

Touch input on mobile devices has one major issue: users typically don't see what they are really doing on the screen because they cannot see below their finger. This is especially problematic when performing drag-and-drop operations on world objects. This asset will help you mitigate that issue.

Finger camera is easy-to-use, modular utility that you can attach to any world object and the camera will follow the object from a specified angle.

This way, users can actually see their actions on the object immediately.

Here is a showcase of the finger camera in provided example scene.

https://github.com/SitronX/UnityFingerCamera/assets/68167377/a584d365-fb17-4b15-a808-cc0eb90f889f

**Note:** Although this asset is primarily designed to mitigate the issue of finger blocking, it can also be used in other scenarios, such as showing what is currently happening on a specific object that the player can't see (e.g., an object placed in another room).

## How to install
You have two options for installing it into your project:

- **First option**: Download the prepared Unity package from the GitHub [release section](https://github.com/SitronX/UnityFingerCamera/releases). After downloading, open your Unity project and simply open the downloaded package. An import dialogue window should appear (Unity should automatically associate the package with itself). If it doesn't work for you, you can also import it through the Unity Package Manager.

- **Second option**: Download this sample project from GitHub and start using it, or just import the FingerCamera folder under `Assets/` into your project.

**Note:** Unity versions 2019+ are officially supported

## Finger Camera features

- Define the starting position of the finger window
- Resize/reposition the window during play
- Customize camera rotations relative to the tracked object
- Zoom in/out of the tracked object
- Option to save window parameters, allowing users to modify them and retain the settings when the game restarts

<img src="https://github.com/SitronX/UnityFingerCamera/assets/68167377/01c2bfb9-e21c-47ee-9eb8-4ca8639424fb"/>

## How to use

Detailed steps on how to use FingerCamera are explained in the [documentation](Documentation.md).

If you still face any problems, feel free to contact me. I can help you out.

## Example scene

An example scene demonstrating basic interaction on a chessboard is available. The scene is located under `Assets/FingerCamera
/ExampleScene`

The example scene is primarily designed for touch controls but can also be controlled with mouse input.

  - Left mouse click: grab the chess piece
  - Right mouse click: move/resize/zoom the finger camera window

**Note:** The example scene is created in the Built-in Render Pipeline. If you want to open it in URP, simply upgrade the scene materials to URP, and everything will work fine.

## Real game showcase

Here is a showcase of this asset in real game.

https://github.com/SitronX/UnityFingerCamera/assets/68167377/03646891-aea1-494d-9bd9-8b01431ac8d7

The game was the main propellant for releasing this asset. You can download it for free on [Google Play](https://play.google.com/store/apps/details?id=com.SitronCOR.Forcel).

Thanks to community support, this is the second feature "gutted" from the game and made open for the community. If you're curious, you can find the first (Time-Rewinding) repository [here](https://github.com/SitronX/UnityTimeRewinder).

## License

This asset is completely free under the [MIT license](https://github.com/SitronX/UnityFingerCamera?tab=MIT-1-ov-file#readme), so you can use it as you wish :)

If you like my projects, please consider buying me a coffee to support my work. All donations will be greatly appreaciated :)

[![BuyMeACoffe](https://github.com/SitronX/UnityFingerCamera/assets/68167377/6559a423-bf31-4c14-96a5-10c0a907944f)](https://buymeacoffee.com/sitronx)
