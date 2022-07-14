using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class load_webserver : MonoBehaviour
{
    public string url;
    void Start() {
       
    StartCoroutine(GetAssetBundle());
    }
    public IEnumerator GetAssetBundle()
    {   /// Code from Unity docs /////////
     UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(url);
     yield return www.SendWebRequest();
     AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);

           if(bundle != null){
            //GameObject g = Instantiate(bundle.LoadAsset("assettest")) as GameObject;  // if you want load gameobject eg. prefab etc..... uncomment the line//////
                string[] scenes = bundle.GetAllScenePaths();
                 
                foreach(string sceneName in scenes){
                    
                SceneManager.LoadScene(Path.GetFileNameWithoutExtension(sceneName), LoadSceneMode.Additive);
             }
       }  
    }
}