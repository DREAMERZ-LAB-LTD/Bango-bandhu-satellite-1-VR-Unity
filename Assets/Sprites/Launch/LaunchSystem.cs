using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchSystem : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject smoke, nextButton, launchButton;
    [SerializeField] bool launch_Rocaket = true;
    [SerializeField] int ejectScene;
    // Start is called before the first frame update
    void Start()
    {
        //Launch();
    }

    public void Launch()
    {
        if (!launch_Rocaket) return;
        launch_Rocaket = false;
        Invoke(nameof(LaunchSmoke), 1f);
        transform.DOMoveY(transform.position.y + 1000f, speed, false).SetEase(Ease.InSine).SetSpeedBased();

        Invoke(nameof(ActivateNextButton), 3f);
    }

    private void LaunchSmoke() 
    { 
        smoke.SetActive(true);    
    }

    public void LoadNextScene() 
    {
        
        SceneManager.LoadScene(ejectScene, LoadSceneMode.Single);
    }

    public void ActivateNextButton() 
    {
        launchButton.SetActive(false);
        nextButton.SetActive(true);
    }
}
