using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using Carousel;
using Carousel.BaselineAgent;


public class XRLocomotionController : UserTransformController
{
    
    public InputActionReference movementAction;
    public InputActionReference orientationAction;
    public InputActionReference orientationPressed;
    public Vector2 movementAxis;
    public Vector2 orientationAxis;
    public float orientationScale = 0.01f;
    public float movementScale = 0.01f;
    public Vector3 localDirection;
    public Transform head;
    public bool activateMovement;
    public bool activateOrientation;
    public bool IsPressed { get; private set; }
    public float timer;
    public float inputInterval = 0.5f;

    void Awake(){
        
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(root == null || head == null) return;
        if(activateOrientation){
            if( orientationPressed.action.phase == InputActionPhase.Performed){
                orientationAxis = orientationAction.action.ReadValue<Vector2>();
    
                if (!IsPressed)
                {
                    Debug.Log("press");
                    IsPressed = true;
                    Rotate(Mathf.Sign(orientationAxis.x));
                    timer = inputInterval;
                }
            }
            
            if (IsPressed && timer < 0)
            {
                IsPressed = false;
            }else if(timer > 0){
                timer-= Time.deltaTime;
            } 
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
    void Rotate(float sign){
        float yAngle = root.rotation.eulerAngles.y;
        yAngle += 45 * sign;
        yAngle %= 360;
        var rootRotation = Quaternion.Euler(new Vector3(0, yAngle, 0));
        Rotate(rootRotation);

    }

    void Rotate(Quaternion q){
        var oldPosition = head.position;
        root.rotation = q;
        var delta = oldPosition - head.position;
        root.position += delta;
    }

    
    public void MoveToNearestAgent(){
        var game = MirrorGameManager.Instance;
        if (game== null) {
           Debug.Log("no instance found");
           return;
        }
        var user = game.player;
        if (user== null) {
           Debug.Log("no user found");
           return;
        }
         NetworkAgentController agent = (NetworkAgentController)GameObject.FindObjectsOfTypeAll(typeof(NetworkAgentController)).FirstOrDefault();
         if(agent== null){
           Debug.Log("no agent found");
           return;
         }
        RPMUserAvatar userAvatar = user.GetComponent<RPMUserAvatar>(); 
        var delta = agent.transform.position - userAvatar.interactionZone.partnerTarget.position;

        root.position += delta;
        Rotate(user.transform.rotation);
       
    }
}
