# Client for ViveTracker based Avatar Synchronization using Mirror

The repository contains a submodule shared with the [server](https://github.com/CarouselDancing/vive-sync-server) and needs to be cloned recursively:

```

git clone git@github.com:CarouselDancing/vive-sync-client.git --recursive

```

The project requires Unity version 2021.3.5f1.

Before opening the project you need to download the data using the PowerShell script /Assets/Resources/download_data.ps1


## Starting the client from the Editor

1. Optional: Configure avatar in the file Assets\Resources\config.json in the field  "rpmURL". (The URL can be recieved by creating a ReadyPlayerMe account)
2. Open the scene Assets\VRAvatarClient\Scenes\Start.unity and press on play
3. The user will start alone in a menu scene with the options Host, Join, Settings or Exit.
   1. Settings: Activate hip and foot trackers and change the protocol (KCP or Telepathy). In order for the Vive trackers to be recognized they need to be assigend to "WAIST", "LEFT FOOT" and "RIGHT FOOT" in the Manage Tracker settings of SteamVR.
   2. Host: Start a server using the selected protocol. Other players can see it now in the server list.
   3. Join: Display the server list. Double click a server to join. The protocol is automatically adjusted based on the server
4. In the main scene the avatar is driven by the headset, hand controllers and Vive Trackers.

## Controls

You can move into the direction of your orientation using the right tackpad.

Pressing the left or right trigger opens a menu attached to the wrist. The menu contains buttons for spawning and deleting simple agents with physics driven animation and external balance. Buttons can be pressed by pointing at them using the other hand and pressing the trigger button. 




