using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SataliteRayAndAniamtonControler : MonoBehaviour
{
    [SerializeField] Animator leftAnimator, rightAnimator;
    [SerializeField] Transform ray;
    [SerializeField] Vector3 rayscale;
    [SerializeField] public static SataliteRayAndAniamtonControler instace;
    [SerializeField] bool showRay = true;
    private void Awake()
    {
        if (instace == null) 
        {
            instace = this;
        }
        else 
        {
            if (instace != this) 
            {
                Destroy(gameObject);
            }
        }
    }
    void Start()
    {
        Invoke(nameof(StartAniation), 1f);
        Invoke(nameof(StartRay), 2);
    }

    private void StartAniation() 
    {
        leftAnimator.SetBool("True", true);
        rightAnimator.SetBool("True", true);
    }
    public void StartRay()
    {
        if (!showRay) return;
        ray.DOScale(rayscale, 1f);
    }

    public void StopRay() 
    {
        ray.DOScale(Vector3.zero, .1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InfoPlace")) 
        {
            showRay = false;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InfoPlace"))
        {
            showRay = true;
        }

    }
}
