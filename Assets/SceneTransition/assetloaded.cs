using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class assetloaded : MonoBehaviour
{
        private AssetBundle assetBundle, assetBundlescene, assetBundlecharacter;
        public string assetbundlename;  //Bundle Name//
        public string gameobject;   //Name of Gameobject//
        private GameObject ob; 
        public string scenebundlename; // Scene bundle name //
        public string scenename; // Scene name you want to load //
        public string characterbundle;   // characterbundle name// 
        public string charactername;     // character name you want to load // 

     void Start()
           {
            loadasset();
            loadscene();
            loadcharacter();
           }

 public void loadasset(){   //////load asset from assetbundle///////////////
            if(assetbundlename != ""){
            assetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/" + assetbundlename);
              
          if(assetBundle != null) {
             ob =  assetBundle.LoadAsset<GameObject>(gameobject);
             Instantiate(ob);
             return;
        }
          assetBundle.Unload(true); /// Cleaning the memory ///
     }
    }

    public void loadscene()  /////load scene from assetbundle//////////////
    {
         if(scenebundlename != ""){
         assetBundlescene = AssetBundle.LoadFromFile("Assets/AssetBundles/" + scenebundlename);
         string[] scenes = assetBundlescene.GetAllScenePaths();
       
         SceneManager.LoadScene(scenes[0], LoadSceneMode.Additive);
        }
       }
     
    public void loadcharacter(){
       if(characterbundle != ""){
       assetBundlecharacter = AssetBundle.LoadFromFile("Assets/AssetBundles/" + characterbundle);
       Object[] allBundles = assetBundlecharacter.LoadAllAssets(); // This line is use to load whole bundle //
          
           foreach (Object o in allBundles)
         {
            if(o.name == charactername){
            Instantiate(o);
            return;
          }
         }
        assetBundle.Unload(true); /// Cleaning the memory ///
 }   
    }
        
 }