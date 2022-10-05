////xr interaction toolkit script with modification/////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class teleport : BaseTeleportationInteractable
{
    public Transform m_TeleportAnchorTransform;
    public Transform xrRig;
    
    void Update(){
     
     
        if(xrRig != null)
            return;
        var m_XROrigin =  GameObject.Find("XR Origin");
        xrRig = m_XROrigin.transform;
       
    }
 
    protected override void Reset()
        {
            base.Reset();
           
        }

    protected void OnDrawGizmos()
        {
            if (m_TeleportAnchorTransform == null)
                return;

            Gizmos.color = Color.blue;
            GizmoHelpers.DrawWireCubeOriented(m_TeleportAnchorTransform.position, m_TeleportAnchorTransform.rotation, 1f);

           
        }
    protected override bool GenerateTeleportRequest(IXRInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            if (m_TeleportAnchorTransform == null)
                return false;
            
           if(raycastHit.collider.gameObject.layer == 7){
                    Debug.Log("layer 7");
            } 
            teleportRequest.destinationPosition = new Vector3(m_TeleportAnchorTransform.position.x ,xrRig.position.y,m_TeleportAnchorTransform.position.z) ;
            teleportRequest.destinationRotation = m_TeleportAnchorTransform.rotation;
            return true;
        }

        
       

}
