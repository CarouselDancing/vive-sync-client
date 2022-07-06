# Client for ViveTracker based Avatar Synchronization using Mirror

The repository contains a submodule shared with the [server](https://github.com/CarouselDancing/vive-sync-server) and needs to be cloned recursively:

```

git clone git@github.com:CarouselDancing/vive-sync-client.git --recursive

```

Requires Unity version 2021.3.5f1.


## Starting the client from the Editor

The client will spawn an avatar in the scene driven by the headset, hand controllers and Vive Trackers.

1. Open the scene Assets\BaselineAgent\Scenes\main.unity
2. Set the target URL and configure the trackers in the file Assets\Resources\config.json (tracker ids are ignored in OpenXR version)
4. Press Play

## Controls

You can move into the direction of your orientation using the right tackpad.

Pressing the left or right trigger opens a menu attached to the wrist. The menu contains buttons for spawning and deleting simple agents with physics driven animation and external balance. Buttons can be pressed by pointing at them using the other hand and pressing the trigger button. 



## Configuration of built executable

Currently remove because StreamingAssets did not work on the Quest.


