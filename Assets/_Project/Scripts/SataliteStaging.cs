using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SataliteStaging : EjectionStage
{
    [SerializeField] Animator leftwing, rightwing;
    [SerializeField] float scaleupTime = 5f, speed = 5, dellay = 3;
    [SerializeField] bool OnStage = false;
    [SerializeField] Transform earth, satalite;
    [SerializeField] SkinnedMeshRenderer ray;
    [SerializeField] float rayScale = 1f;

    
    protected override void ExecuteOperation()
    {
        // invock after 3rd stage complete;
        transform.parent = null;
        satalite.DORotate(Vector3.zero, dellay).OnComplete(() =>
        {
            satalite.DOScale(Vector3.one, scaleupTime).OnComplete(() =>
            {
                //start ray
                leftwing.SetBool("True", true);
                rightwing.SetBool("True", true);
                OnStage = true;
                satalite.DOLookAt(Vector3.zero, dellay).OnComplete(() => {

                    ray.transform.DOScale(Vector3.one * rayScale, dellay);
;                }
                );
            });
        }).SetEase(Ease.Linear);
        
    }


    private void StartRotateArrountEarth() 
    {
        // start ray
    }

    private void OnEnable()
    {
        ExecuteOperation();
    }
    private void Update()
    {
        if (OnStage) return;

        transform.DOLocalMove(transform.position + transform.up * Time.deltaTime * speed, Time.deltaTime, false);
    }

}
