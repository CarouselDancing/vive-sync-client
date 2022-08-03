using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

[Serializable]
public struct SettingsElements{

    public Toggle hipTrackerToggle;
    public Toggle footTrackersToggle;
    public InputField hipPosOffset;
    public InputField hipRotOffset;
    public InputField leftFootPosOffset;
    public InputField leftFootRotOffset;
    public InputField rightFootPosOffset;
    public InputField rightFootRotOffset;

    public void Save(ref ClientConfig config){
        config.activateHipTracker = hipTrackerToggle.isOn;
        config.activateFootTrackers = footTrackersToggle.isOn;
        StringToArray(hipPosOffset.text, ref config.hipTracker.posOffset, 3);
        StringToArray(hipRotOffset.text, ref config.hipTracker.rotOffset, 3);

        StringToArray(leftFootPosOffset.text, ref config.leftFootTracker.posOffset, 3);
        StringToArray(leftFootRotOffset.text, ref config.leftFootTracker.rotOffset, 3);

        StringToArray(rightFootPosOffset.text, ref config.rightFootTracker.posOffset, 3);
        StringToArray(rightFootRotOffset.text, ref config.rightFootTracker.rotOffset, 3);
    }

    public void Show(ref ClientConfig config){
        hipTrackerToggle.isOn = config.activateHipTracker;
        footTrackersToggle.isOn = config.activateFootTrackers;
        hipPosOffset.text = ArrayToString(config.hipTracker.posOffset, 3);
        hipRotOffset.text = ArrayToString(config.hipTracker.rotOffset, 3);
        leftFootPosOffset.text = ArrayToString(config.leftFootTracker.posOffset, 3);
        leftFootRotOffset.text = ArrayToString(config.leftFootTracker.rotOffset, 3);
        rightFootPosOffset.text = ArrayToString(config.rightFootTracker.posOffset, 3);
        rightFootRotOffset.text = ArrayToString(config.rightFootTracker.rotOffset, 3);

    }

    public string ArrayToString(float[] array, int size){
        string str = "";
        for(int i =0; i < size; i++){
            str += array[i].ToString();
            if (i < size-1) str+=", ";
        }
        return str;
    }    
    public bool StringToArray(string str, ref float[] array, int size){
        var splitStr = str.Split(",");
        List<float> floatList = new List<float>();
        if (splitStr.Length != size)return false;

        for(int i =0; i < splitStr.Length; i++){
            try{
                float f = Single.Parse(splitStr[i]);
                if (!Single.IsNaN(f)) floatList.Add(f);
            }catch{
                continue;
            }
        }
        if (floatList.Count != size)return false;
        array = floatList.ToArray();
        return true;
    }
}

public class MainMenuController : MonoBehaviour
{
    public enum MenuState{
        MAIN,
        SERVER_LIST,
        SETTINGS
    }
    public GameObject mainPanel;
    public GameObject serverListPanel; 
    public GameObject settingsPanel; 
    public GameObject contentObject;
    public MenuState state;
    public GameObject entryPrefab;
    public string method;

    MirrorGameManager manager;

    public List<GameObject> serverList;
    public SettingsElements settingsElements;

    public void Start(){
        serverList = new List<GameObject>();
        manager = MirrorGameManager.Instance;
    }

    public void Host(){
        manager.HostServer();
    }   
    
     public void ExitGame(){
        manager.ExitGame();
    }


    public void ShowServerList(){
        state = MenuState.SERVER_LIST;
        ClearServerList();
        mainPanel.SetActive(false);
        serverListPanel.SetActive(true);
        settingsPanel.SetActive(false);
        FillServerList();

    }

    public void ShowMain(){
        if (manager != null && state == MenuState.SETTINGS){
            settingsElements.Save(ref manager.config);
        }
        state = MenuState.MAIN;
        mainPanel.SetActive(true);
        serverListPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ShowSettings(){
        state = MenuState.SETTINGS;
        if(manager != null)settingsElements.Show(ref manager.config);
        mainPanel.SetActive(false);
        serverListPanel.SetActive(false);
        settingsPanel.SetActive(true);
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
