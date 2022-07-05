/* This script will connect grabber components for left and right hand to XRInputActions and then delete itself*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Carousel.BaselineAgent;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.Events;


namespace Carousel{
public class XRGrabControlInitializer : MonoBehaviour
{
    public InputActionReference leftAction; 
    public InputActionReference rightAction; 

    // Update is called once per frame
    void Update()
    {
        var player = MirrorGameManager.Instance.player;
        if (player != null){
            var userAvatarCommands = player.GetComponent<UserAvatarCommands> ();
            CreateInputMapping(player.leftGrabber, userAvatarCommands);
            CreateInputMapping(player.rightGrabber, userAvatarCommands);
            DestroyImmediate(this);
       }
        
    }

    void CreateInputMapping(RBGrabber grabber, UserAvatarCommands commands){
        var inputMapping = grabber.gameObject.AddComponent<XRInputActionController>();
        
        inputMapping.OnPress = new UnityEvent();
        inputMapping.OnRelease = new UnityEvent();

        if (grabber.side == RBGrabber.Side.LEFT){
            inputMapping.inputAction = leftAction;
            inputMapping.OnPress.AddListener(commands.GrabLeft);
            inputMapping.OnRelease.AddListener(commands.ReleaseLeft);
        }else{
            inputMapping.inputAction = rightAction;
            inputMapping.OnPress.AddListener(commands.GrabRight);
            inputMapping.OnRelease.AddListener(commands.ReleaseRight);

        }
    }
}

}