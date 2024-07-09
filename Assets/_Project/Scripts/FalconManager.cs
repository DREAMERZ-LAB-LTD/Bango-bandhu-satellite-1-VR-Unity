using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using PathCreation.Examples;

public class FalconManager : MonoBehaviour
{
    [SerializeField] FirstStage falconLaunchStage;

    [ContextMenu("LaunchRocket")]
    public void LaunchRocket() 
    {
        falconLaunchStage.enabled = true;
    }
    

}
