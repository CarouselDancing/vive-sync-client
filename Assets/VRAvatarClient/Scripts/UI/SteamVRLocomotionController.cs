using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamVRLocomotionController : MonoBehaviour
{
    
    public SteamVR_Action_Vector2 action;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.RightHand;//which controller
    public Vector2 axis;
    public Vector3 direction;
    public float scale = 0.01f;
    public Vector3 locomotionOffset;
    public Transform root;
    public Transform head;

    void Update()
    {
        axis = action.GetAxis(inputSource);
        direction.x = axis.x;
        direction.y = 0;
        direction.z = axis.y;
        if(root != null && head !=null){
            var rotation = Quaternion.Euler(new Vector3(0, head.rotation.eulerAngles.y, 0));
            root.position +=  rotation* (scale * direction);
         }

    }
}
