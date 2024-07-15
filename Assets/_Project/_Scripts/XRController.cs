using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class XRController : MonoBehaviour
{
    public static XRController instance;


    public OVRPassthroughLayer passthroughLayer;

    public PassThoroughState pState = PassThoroughState.none;
    public TextMeshProUGUI passTxt;

    public GameObject _enviroments;
    public OVRCameraRig ovrCameraRig;

    [SerializeField] int nextScene;

    private void Awake()
    {
        if(instance == null)
        instance = this;
    }

    private void Start()
    {

       // ovrCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();
       // ChangePassthroughState();
    }


    private void ChangePassthroughState()
    {
       /* if (ovrCameraRig == null)
        {
            ovrCameraRig = GameObject.Find("OVRCameraRig").GetComponent<OVRCameraRig>();
        }*/
        
    
        var centerCamera = ovrCameraRig.centerEyeAnchor.GetComponent<Camera>();
        if (centerCamera == null) return;
        switch (pState)
        { 
            case PassThoroughState.none:
                _enviroments.SetActive(true);
                passthroughLayer.enabled = false;
                centerCamera.clearFlags = CameraClearFlags.Skybox;
                passTxt.text = "Off";
                break;
            case PassThoroughState.passthrough:
                _enviroments.SetActive(false);
                if (OVRManager.IsPassthroughRecommended())
                {
                    passthroughLayer.enabled = true;
                    // Set camera background to transparent
                    centerCamera.clearFlags = CameraClearFlags.SolidColor;
                    passTxt.text = "On";
                }

              
                break;
        }
    }


    public void SwitchPassthrough()
    {
        print("switch Passthrough ");

        if (pState == PassThoroughState.none)
            pState = PassThoroughState.passthrough;
        else
            pState = PassThoroughState.none;


        ChangePassthroughState();
    }

    public void ReturnLaunch()
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }

}




public enum PassThoroughState { 
    none,
    passthrough
}
