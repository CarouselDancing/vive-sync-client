////xr interaction toolkit script with modification/////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class teleport : BaseTeleportationInteractable
{
    public Transform m_TeleportAnchorTransform;
    public Transform xrRig;
   
    public void TeleportorPointing(HoverEnterEventArgs args)
    {
        var raycolor = args.interactorObject.transform.GetComponent<Renderer>();
        raycolor.material.SetColor("_Color", Color.blue);
        raycolor.material.SetColor("_EmissionColor", Color.blue);
    }
    public void TeleportorPointingExit(HoverExitEventArgs args)
    {
        var raycolor = args.interactorObject.transform.GetComponent<Renderer>();
        raycolor.material.SetColor("_Color", Color.red);
        raycolor.material.SetColor("_EmissionColor", Color.red);
    }
    
    void Update(){ 
        if(xrRig != null)return;
        var m_XROrigin =  GameObject.Find("XR Origin");
        xrRig = m_XROrigin.transform;    
        }
    
    private void OnTriggerStay(Collider other){
        this.gameObject.GetComponent<Collider>().isTrigger = true;
    }
    
    private void OnTriggerExit(Collider other){
        this.gameObject.GetComponent<Collider>().isTrigger = false;
    }
  
    protected override bool GenerateTeleportRequest(XRBaseInteractor interactor, RaycastHit raycastHit, ref TeleportRequest teleportRequest)
        {
            if (m_TeleportAnchorTransform == null)
                return false;
            /*if(raycastHit.collider.gameObject.layer == 7){
                    Debug.Log("layer 7");
                    Debug.Log(interactor.gameObject.name);
            }*/
            teleportRequest.destinationPosition = new Vector3(m_TeleportAnchorTransform.position.x ,xrRig.position.y,m_TeleportAnchorTransform.position.z) ;
            teleportRequest.destinationRotation = m_TeleportAnchorTransform.rotation;
            return true;
        }
}
