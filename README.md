# Client for ViveTracker based Avatar Synchronization using Mirror

The repository contains a submodule shared with the [server](https://github.com/CarouselDancing/vive-sync-server) and needs to be cloned recursively:

```

git clone git@github.com:CarouselDancing/vive-sync-client.git --recursive

```

The project requires Unity version 2021.3.5f1.

Before opening the project you need to download the data using the PowerShell script /Assets/Resources/download_data.ps1


## Starting the client from the Editor

The client will spawn an avatar in the scene driven by the headset, hand controllers and Vive Trackers.

1. Open the scene Assets\BaselineAgent\Scenes\main.unity
2. Configure mirror and the trackers in the file Assets\Resources\config.json 
   1. Set "networkMode" to "host" or "client"
   2. if client is selected an url and the port need to be provided
   3. The avatar can be specified in "rpmURL" "which can be recieved by creating a ReadyPlayerMe account
   4. Optional hip and foot trackers can be activated. Tracker ids are ignored in OpenXR version.
3. Press Play

## Controls

You can move into the direction of your orientation using the right tackpad.

Pressing the left or right trigger opens a menu attached to the wrist. The menu contains buttons for spawning and deleting simple agents with physics driven animation and external balance. Buttons can be pressed by pointing at them using the other hand and pressing the trigger button. 




