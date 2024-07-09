using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSystem : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject smoke;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }

    private void Launch()
    {
        
        transform.DOMoveY(transform.position.y + 1000f, speed, false).SetEase(Ease.InSine).SetSpeedBased();
        Invoke(nameof(LaunchSmoke), 0.5f);
    }

    private void LaunchSmoke() { smoke.SetActive(true);}
}
