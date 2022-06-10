using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Carousel.BaselineAgent;

public class RegisterSteamVRController : MonoBehaviour
{

    public SteamVRButtonController leftController;
    public SteamVRButtonController rightController;
    public RBGrabber leftGrabber;
    public RBGrabber rightGrabber;

    void Update()
    {
        if(leftGrabber == null || rightGrabber == null) {
            RegisterControllers();
        }else{
            DestroyImmediate(this);
        }
    }

    void RegisterControllers(){
        var grabbers = GameObject.FindObjectsOfTypeAll(typeof(RBGrabber));
        foreach(RBGrabber grabber in grabbers){
            if (grabber.side == RBGrabber.Side.RIGHT){
                if(rightGrabber==null) {
                    RegisterController(grabber, rightController, SteamVR_Input_Sources.RightHand);
                    rightGrabber = grabber;
                }
            }else{
                if(leftGrabber == null) {
                    RegisterController(grabber, leftController, SteamVR_Input_Sources.LeftHand);
                    leftGrabber = grabber;
                }
            }
        }
    }

    void RegisterController(RBGrabber grabber, SteamVRButtonController buttonController,SteamVR_Input_Sources inputSource){
        buttonController.action = SteamVR_Actions.default_GrabGrip;
        buttonController.inputSource = inputSource;
        buttonController.OnPress.AddListener(grabber.GrabObject);
        buttonController.OnRelease.AddListener(grabber.ReleaseObject);
    }
}
