using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;




public class scenemanager : MonoBehaviour
{
    public GameObject loadingscreen;
    public static string main;
    public Slider slider;


   public void OXRClientScene()
   {
     main = "OXRClient";
     StartCoroutine(LoadYourAsyncScene());
   }
   
    public void mainscene()
   {
     main = "main";
     StartCoroutine(LoadYourAsyncScene());
   }

    public void ExitGame()
   {
    Debug.Log("GameExit");
   }
   
IEnumerator LoadYourAsyncScene()
    {
        
      AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(main);
        if(main == "OXRClient"){
        SceneManager.LoadScene("ModifiedEnvironment_V2_no_logic", LoadSceneMode.Additive);
        }
       
        loadingscreen.SetActive(true);
        // asyncLoad.allowSceneActivation = false;
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
        //int progress = (int)(asyncLoad * 100f);
         float loading = Mathf.Clamp01(asyncLoad.progress / .9f);
         
         slider.value = loading;
        // Debug.Log(asyncLoad.progress * 100);
        
        
         yield return null;} 
         }


}



