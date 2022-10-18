using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
  private GameObject[] gos;
  public List<GameObject> teleport;
  public bool teleportation = true;
  
  private void Start(){
      teleport = new List<GameObject>();
    }
  
  private void Update(){
      gos = FindObjectsOfType(typeof(GameObject)) as GameObject[];
    foreach (GameObject go in gos)
        {
          if(go.layer == 7)
            {
              if(go != null && !teleport.Contains(go)) {
              teleport.Add(go);
            } 
          }
        }
      }

  public void teleportationActivate(){
       if(teleportation==true)return;
        if(teleportation == false){
          foreach(var g in teleport) {
          g.SetActive(true);
          teleportation = true;
        } 
      }
    }
  public void teleportationDeactivate(){
          if(teleportation==false)return;
           if(teleportation == true){  
            foreach(var g in teleport) {
            Debug.Log("teleportation is deActivate");
            g.SetActive(false);
            teleportation = false;
        }
      }
    }
}   
