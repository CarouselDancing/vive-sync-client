using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RestrictCanvasRotation : MonoBehaviour
{
  Vector3 savedpos;

  //   public GameObject gObject;
    float lockRotation, lockpositiony;
     RectTransform transf;
    // Start is called before the first frame update
    void Start()
    {
         transf = GetComponent<RectTransform> ();
         lockRotation = 0.0f;
         //lockpositiony = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transf.rotation = Quaternion.Euler (lockRotation, transform.eulerAngles.y, lockRotation);
        transf.localPosition = new Vector3(transform.localPosition.x, 0f ,1f);
        
        
        

     }
     void FixedUpdate(){
     //     transform.position= savedpos;
     }





}

  /*   Vector3 savedPosition;
     
         [Tooltip("When DontMoveWithParent is on, Ctrl+Z doesn't work for movement changes on this GameObject.")]
         public bool dontMoveWithParent = true;
         bool lastDontMoveWithParent = true;
     
         Vector3 parentLastPos;
     
         private void Update()
         {
             if (transform.hasChanged && !transform.parent.hasChanged && savedPosition != transform.position)
             {
                 savedPosition = transform.position;
                 transform.hasChanged = false;
             }
     
             if (!lastDontMoveWithParent && dontMoveWithParent)
                 savedPosition = transform.position;
     
                 lastDontMoveWithParent = dontMoveWithParent;
         }
     private void FixedUpdate(){

     }
         private void LateUpdate()
         {
             if (dontMoveWithParent)
             {
                 if (savedPosition == Vector3.zero)
                 {
                     savedPosition = transform.position;
                 }
     
                 if (transform.parent.hasChanged)
                 {
                     transform.position = savedPosition;
                     transform.parent.hasChanged = false;
                 }
             }
         }
     }  */


