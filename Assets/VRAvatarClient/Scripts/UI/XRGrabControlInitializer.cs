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
            CreateInputMapping(player.leftGrabber);
            CreateInputMapping(player.rightGrabber);
            DestroyImmediate(this);
       }
        
    }

    void CreateInputMapping(RBGrabber grabber){
        var inputMapping = grabber.gameObject.AddComponent<XRInputActionController>();
        if (grabber.side == RBGrabber.Side.LEFT){
            inputMapping.inputAction = leftAction;
        }else{
            inputMapping.inputAction = rightAction;

        }
        inputMapping.OnPress = new UnityEvent();
        inputMapping.OnPress.AddListener(grabber.GrabObject);
        inputMapping.OnRelease = new UnityEvent();
        inputMapping.OnRelease.AddListener(grabber.ReleaseObject);
    }
}

}