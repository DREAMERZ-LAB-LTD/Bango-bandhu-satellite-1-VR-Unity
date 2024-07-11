using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SecoendStage : EjectionStage
{

    [SerializeField] Transform firstStageReturn;
    [SerializeField] Transform secondStageObject;
    [SerializeField] float speed;
    [SerializeField] Ease launchEase;
    [SerializeField] bool sataliteRelise = false;
    [SerializeField] float releseDelay = 5f;

    //rotation section
    [SerializeField] Ease rotatonEase = Ease.OutQuint;
    [SerializeField] Vector3 rotaton = Vector3.zero;
    [SerializeField] float secoendStageDuration = 10f;
    [SerializeField] float releseAngle = 90f;

    //partical
    [SerializeField] ParticleSystem particleSystem;

    private void OnEnable()
    {
        ExecuteOperation();
    }
    protected override void ExecuteOperation()
    {
        this.transform.parent = null;
        Transform temp = firstStageReturn.transform.parent;
        firstStageReturn.parent = null;
        temp.gameObject.SetActive(false);
        particleSystem.Play();
        transform.DORotate(rotaton * releseAngle, secoendStageDuration, RotateMode.FastBeyond360).SetEase(rotatonEase).OnComplete(StartThirdStage);

    }

    private void Update()
    {
        if (sataliteRelise) return;

        transform.DOLocalMove(transform.position + transform.up * Time.deltaTime * speed, Time.deltaTime, false).SetEase(launchEase);
    }

    public void StopSecoendStage() 
    {
         sataliteRelise = true;
         enabled = false;
        particleSystem.Stop();
    }
    private void StartThirdStage()
    {        
        if(nextejection != null)
            nextejection.enabled = true;
    }

}
