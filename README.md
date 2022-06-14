# SteamVR client for the Synchronization of IKRig based Avatars using Mirror

The repository contains a submodule shared with the [server](https://github.com/CarouselDancing/vive-sync-server) and needs to be cloned recursively:

```

git clone git@github.com:CarouselDancing/vive-sync-client.git --recursive

```

Requires Unity version 2020.3.20f1.


## Starting the client from the Editor

The client will spawn an avatar in the scene driven by the headset and hand controllers.

1. Open the scene Assets\VRAvatarClient\Scenes\VRClient_ui.unity
2. Set the target URL and configure the trackers in the file Assets\StreamingAssets\config.json
3. To get the right device IDs for the trackers you can set activateDebugVis to true. This will enable a debug mode that shows all devices and their ID instead of connecting to a server.
4. Press Play

## Controls

You can move into the direction of your orientation using the right tackpad.

Pressing the left or right trigger opens a menu attached to the wrist. The menu contains buttons for spawning and deleting simple agents with physics driven animation and external balance. Buttons can be pressed by pointing at them using the other hand and pressing the trigger button. 



## Configuration of built executable

The configuration file will be located in the directory <build-dir>\vive_sync_client_Data\StreamingAssets\config.json


