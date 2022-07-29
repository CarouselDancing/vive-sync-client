using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selectable_Asset : MonoBehaviour
{
    public List <GameObject> partner;
    GameObject button;
    public GameObject buttonPrefab;
    public GameObject panel;
    
   
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

       Debug.Log(go.name);
       if(go != null && !partner.Contains(go)){
        partner.Add(go);

       }
   }
   public void clearlist(){
      partner.Clear();
   }


public void print(){
    
    foreach (var item in partner)
        {
            /// Instantiates the button /// 
            button = (GameObject)Instantiate(buttonPrefab);
            button.transform.SetParent(panel.transform, false);
            button.GetComponent<Button>().onClick.AddListener(OnClick);
            button.transform.GetChild(0).GetComponent<Text>().text = item.name;   
        }
     }

void OnClick()
    {
        Debug.Log("clicked!");
      
    }
}