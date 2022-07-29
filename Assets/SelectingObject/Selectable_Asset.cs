using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Selectable_Asset : MonoBehaviour
{
    public List <GameObject> partner;
    GameObject button;
    public GameObject buttonPrefab, panel;
    
    
    void Start(){
     partner = new List<GameObject>();
     GameObject empty = new GameObject("Emptygameobject");
     partner.Add(empty);
     }

    public void Selectable(){
        Debug.Log("Object is Pointed");
     
    }

    public void ButtonHover(){
        Debug.Log("Button is Select");
    
    }
    public void Unselect(){
        UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject (null);
        Debug.Log("UnSelected");
    
    }
   public void storelist(GameObject go){

       if(go != null && !partner.Contains(go)){
        partner[0] = go;
 }
   }

   public void print(){
      foreach (var item in partner)
        {
            ///Things to do. updating the gameobject in the canvas //
            /// Instantiates the button/// 
            button = (GameObject)Instantiate(buttonPrefab);
            button.transform.SetParent(panel.transform, false);
            button.transform.GetChild(0).GetComponent<Text>().text = item.name; 
        }
    }
}