using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.Events;

public class SteamVRButtonController : MonoBehaviour
{

    public SteamVR_Action_Boolean action;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
 
        [Tooltip("Event when the button starts being pressed")]
        public UnityEvent OnPress;
 
        [Tooltip("Event when the button is released")]
        public UnityEvent OnRelease;


    // to check whether it's being pressed
    public bool IsPressed { get; private set; }
 
 
    void Update()
    {
        if (action.GetState(inputSource) || action.GetStateDown(inputSource))
        {
            Debug.Log("is pressed");
            if (!IsPressed)
            {
                IsPressed = true;
                OnPress.Invoke();
            }
        }  else if (IsPressed)
        {
            IsPressed = false;
            OnRelease.Invoke();
        }
    }
}
