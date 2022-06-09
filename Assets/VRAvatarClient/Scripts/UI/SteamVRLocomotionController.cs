using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SteamVRLocomotionController : MonoBehaviour
{
    
    public SteamVR_Action_Vector2 action;
    public SteamVR_Input_Sources movementSource = SteamVR_Input_Sources.RightHand;
    public SteamVR_Input_Sources orientationSource = SteamVR_Input_Sources.LeftHand;
    public Vector2 movementAxis;
    public Vector2 orientationAxis;
    public float orientationScale = 0.01f;
    public float movementScale = 0.01f;
    public Vector3 localDirection;
    public Transform root;
    public Transform head;
    public bool activateMovement;
    public bool activateOrientation;

    void Update()
    {
        if(root == null || head == null) return;
        if(activateOrientation){
            orientationAxis = action.GetAxis(orientationSource);
            float yAngle = root.rotation.eulerAngles.y;
            yAngle += orientationScale * orientationAxis.x;
            yAngle %= 360;
            var rootRotation = Quaternion.Euler(new Vector3(0, yAngle, 0));
            root.rotation = rootRotation;
        }
        if (activateMovement){
            movementAxis = action.GetAxis(movementSource);
            localDirection.x = movementAxis.x;
            localDirection.y = 0;
            localDirection.z = movementAxis.y;
            var headRotation = Quaternion.Euler(new Vector3(0, head.rotation.eulerAngles.y, 0));
            root.position +=  headRotation* (movementScale * localDirection);
        }

    }
}
