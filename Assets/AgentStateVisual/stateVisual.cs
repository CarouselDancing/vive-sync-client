using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Carousel.BaselineAgent;
using UnityEngine.UI;

namespace Carousel{
public class stateVisual : MonoBehaviour
{
    public Transform AgentName;
    Text txt;
    
    public void Awake(){
      AgentName =  this.transform.Find("Panel/TextName");
      var AgentStatus = this.transform.Find("Panel/TextAgentInteraction");
      txt = AgentStatus.GetComponent<Text>();
      }
       
       public void FollowVisual(){
        txt.text  = "AGENT IS FOLLOWING";
      }
      
      public void ActivateVisual(){
        txt.text  = "AGENT IS ACTIVATE";
      }
      
      public void DeactivateVisual(){
        txt.text  = "AVAILABLE FOR DANCE";
      }
      
      public void MirroringVisual(){
        txt.text  = "AGENT IS MIRRORING";
      }
    }   
}

