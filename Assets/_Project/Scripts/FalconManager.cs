using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using PathCreation.Examples;

public class FalconManager : MonoBehaviour
{
    [SerializeField] FirstStage falconLaunchStage;
    [SerializeField] float TotalTinme = 30f;
    [SerializeField] Vector3 startRotaton;
    [SerializeField] Transform earth;
    [SerializeField] ParticleSystem rocaketPartical;
    [ContextMenu("LaunchRocket")]
    public void LaunchRocket() 
    {
        falconLaunchStage.enabled = true;
        earth.DORotate(new Vector3(0f, 109.599991f, -0f), TotalTinme, RotateMode.Fast).SetEase(Ease.Linear);
        rocaketPartical.Play();
    }
    

}
