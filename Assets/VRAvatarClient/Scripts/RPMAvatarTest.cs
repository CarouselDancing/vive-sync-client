using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe;


public class RPMAvatarTest : MonoBehaviour
{
    public string AvatarURL = "";
    public GameObject go;
    public RuntimeAnimatorController animationController;
    public bool initiated = false;
    public bool processing = false;
    private void Start()
    {

      
        var config = ClientConfig.GetInstance();
        var avatarIndex = config.userAvatar;
        AvatarURL = config.rpmAvatars[avatarIndex].url;
        if (AvatarURL != "") SetupAvatarControllerFromRPM(AvatarURL);
        processing = true;
      
    }


    void SetupAvatarControllerFromRPM(string url)
    {
        AvatarLoader avatarLoader = new AvatarLoader();
        Debug.Log($"Started loading avatar. [{Time.timeSinceLevelLoad:F2}]");
        avatarLoader.LoadAvatar(url, OnAvatarImported, OnRPMAvatarLoaded);
    }

    public void OnAvatarImported(GameObject avatar)
    {
        go = avatar;
        avatar.transform.parent = transform;
        Debug.Log($"Avatar imported. [{Time.timeSinceLevelLoad:F2}]");
        processing = false;
    }


    public void OnRPMAvatarLoaded(GameObject avatar, AvatarMetaData metaData = null)
    {
        
        var config = ClientConfig.GetInstance();
        bool activateFootRig = config.activateFootTrackers;
        var ikRigBuilder = new RPMIKRigBuilder(animationController, activateFootRig);
        var rigConfig = ikRigBuilder.Build(avatar);
        SetupRig(rigConfig, avatar);
        Debug.Log($"Avatar loaded. [{Time.timeSinceLevelLoad:F2}]\n\n{metaData}");
        initiated = true;
    }


    void SetupRig(CharacterRigConfig rigConfig, GameObject avatar)
    {
        InitVRRig vrRig = avatar.AddComponent<InitVRRig>();
        vrRig.SetupAvatarController(rigConfig, avatar);
        var animator = avatar.GetComponent<Animator>();
        vrRig.ConnectTrackers();
    }
}
