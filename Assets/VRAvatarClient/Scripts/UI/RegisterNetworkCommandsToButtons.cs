using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Carousel.BaselineAgent;
using System.Linq;

public class RegisterNetworkCommandsToButtons : MonoBehaviour
{
  public SteamVRButtonController leftController;
    public SteamVRButtonController rightController;
    public UserAvatarCommands commands;

    void Update()
    {
        if(commands == null) {
            RegisterControllers();
        }else{
            DestroyImmediate(this);
        }
    }

    void RegisterControllers(){
        commands = (UserAvatarCommands)GameObject.FindObjectsOfTypeAll(typeof(UserAvatarCommands)).FirstOrDefault();
        if(commands !=null){
            RegisterController(rightController, SteamVR_Input_Sources.RightHand, UserAvatarCommands.RIGHT);
            RegisterController(leftController, SteamVR_Input_Sources.LeftHand, UserAvatarCommands.LEFT);
        }
    }

    void RegisterController(SteamVRButtonController buttonController,SteamVR_Input_Sources inputSource, int side){
        buttonController.action = SteamVR_Actions.default_GrabGrip;
        buttonController.inputSource = inputSource;
        buttonController.OnPress.AddListener(()=> commands.Grab(side));
        buttonController.OnRelease.AddListener(()=> commands.Release(side));
    }
}
