using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;


public class XRLocomotionController : MonoBehaviour
{
    
    public InputActionReference movementAction;
    public InputActionReference orientationAction;
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
            orientationAxis = orientationAction.action.ReadValue<Vector2>();
            float yAngle = root.rotation.eulerAngles.y;
            yAngle += orientationScale * orientationAxis.x;
            yAngle %= 360;
            var rootRotation = Quaternion.Euler(new Vector3(0, yAngle, 0));
            root.rotation = rootRotation;
        }
        if (activateMovement){
            
            movementAxis = movementAction.action.ReadValue<Vector2>();
            localDirection.x = movementAxis.x;
            localDirection.y = 0;
            localDirection.z = movementAxis.y;
            var headRotation = Quaternion.Euler(new Vector3(0, head.rotation.eulerAngles.y, 0));
            root.position +=  headRotation* (movementScale * localDirection);
        }

    }
}
