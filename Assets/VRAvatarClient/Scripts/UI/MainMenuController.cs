using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;


public class MainMenuController : MonoBehaviour
{
    public enum MenuState{
        MAIN,
        SERVER_LIST
    }
    public GameObject mainPanel;
    public GameObject serverListPanel; 
    public GameObject contentObject;
    public MenuState state;
    public GameObject entryPrefab;
    public string method;

    MirrorGameManager manager;

    public List<GameObject> serverList;

    public void Start(){
        serverList = new List<GameObject>();
        manager = MirrorGameManager.Instance;
    }

    public void ShowServerList(){
        state = MenuState.SERVER_LIST;
        ClearServerList();
        mainPanel.SetActive(false);
        serverListPanel.SetActive(true);
        FillServerList();

    }

    public void ShowMain(){
        state = MenuState.MAIN;
        mainPanel.SetActive(true);
        serverListPanel.SetActive(false);
    }

    public void FillServerList(){
        Debug.Log("fill server list");
        StartCoroutine(manager.sendGETRequestCoroutine(method, HandleServerList));
    }


    public void HandleServerList(string responseText){
        JsonSerializer serializer = new JsonSerializer();
        Debug.Log(responseText);
        JsonReader reader = new JsonTextReader(new StringReader(responseText));
        var newServerEntries = serializer.Deserialize<List<ServerEntry>>(reader);
        foreach (var s in newServerEntries) {
            var so = GameObject.Instantiate(entryPrefab, contentObject.transform);
            var t = so.GetComponentInChildren<Text>();
            t.text = s.address;
            var b = so.GetComponent<Button>();
            b.onClick.AddListener(() => {
                manager.JoinServer(s.address);
            });
            serverList.Add(so);
        }
     
    }

    void ClearServerList(){
        foreach (var s in serverList) {
            GameObject.Destroy(s);
        }
        serverList = new List<GameObject>();
    }


}
