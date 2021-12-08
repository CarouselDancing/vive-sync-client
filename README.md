# SteamVR client for the Synchronization of IKRig based Avatars using Mirror

The repository contains a submodule shared with the [server](https://github.com/CarouselDancing/vive-sync-server) and needs to be cloned recursively:

```

git clone git@github.com:CarouselDancing/vive-sync-client.git --recursive

```

Requires Unity version 2020.3.20f1.


## Starting the client from the Editor

The client will spawn an avatar in the scene driven by the headset and hand controllers.

1. Open the scene Assets\VRAvatarClient\Scenes\VRClient.unity
2. Set the target URL in the file Assets\StreamingAssets\config.json
3. Press Play



## Configuration of built executable

The configuration file will be located in the directory <build-dir>\vive_sync_client_Data\StreamingAssets\config.json


