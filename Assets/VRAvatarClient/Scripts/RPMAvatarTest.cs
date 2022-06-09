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

      
        AvatarURL = GlobalGameState.GetInstance().config.rpmURL;
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
        bool activateFootRig = GlobalGameState.GetInstance().config.activateFootTrackers;
        var ikRigBuilder = new RPMIKRigBuilder(animationController, activateFootRig);
        var config = ikRigBuilder.Build(avatar);
        SetupRig(config, avatar);
        Debug.Log($"Avatar loaded. [{Time.timeSinceLevelLoad:F2}]\n\n{metaData}");
        initiated = true;
    }


    void SetupRig(CharacterRigConfig config, GameObject avatar)
    {
        InitVRRig vrRig = avatar.AddComponent<InitVRRig>();
        vrRig.SetupAvatarController(config, avatar);
        var animator = avatar.GetComponent<Animator>();
        vrRig.ConnectTrackers();
    }
}
