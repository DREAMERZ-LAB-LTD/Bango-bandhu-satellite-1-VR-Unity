using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public TextMeshProUGUI _Title;
    public TextMeshProUGUI _Description;
    public GameObject PipUp;
    public AudioSource audioSource;
    public Image _panelImage;
    private void Start()
    {
        PipUp.SetActive(true);
       // SolarController.instance.OnSolarEventTriggered += DisplayInfo;
        _Title.text = "";
        _Description.text = "";
    }
    private void OnDisable()
    {
       // SolarController.instance.OnSolarEventTriggered -= DisplayInfo;
    }
/*
    private void DisplayInfo(Solar _solar)
    {
        PlanetInfo _planetInfo = null;

        foreach(var info in SolarController.instance.solarData.planets)
        {
            if(info.solar == _solar)
            {
                _planetInfo = info;
               //break;
            }
        }

        if (_planetInfo != null)
        {
            _Title.text = _planetInfo.solar.ToString();
            _Description.text = _planetInfo.description;
             PipUp.SetActive(false);
            _panelImage.enabled = false;
            audioSource.clip = _planetInfo._audioClip;
            if(audioSource.clip != null) { audioSource.Play(); } // Play Audio if _aduioSource is not null 
        }
        else
        {
            Debug.Log("Planet not found.");
            _Title.text ="";
            _Description.text = "";
            PipUp.SetActive(true);
            _panelImage.enabled = true;
            if (audioSource.clip != null) { audioSource.Stop(); } // Stop Audio Source 
        }
    }
*/

}
