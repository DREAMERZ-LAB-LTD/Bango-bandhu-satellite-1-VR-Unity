using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstStage : EjectionStage
{
    [SerializeField] float speed = 10f;
    [SerializeField] float first_ejection_time = 6f;
    [SerializeField] Ease launchEase = Ease.Linear;
    [SerializeField] Ease rotatonEase = Ease.OutQuint;
    [SerializeField] Vector3 rotaton = Vector3.zero;
    [SerializeField] float carvePathDellay = 3f;
    [SerializeField] float releseAngle = 90f;
    [SerializeField] Firstagelanding firstagelanding;

    private void OnEnable()
    {
        ExecuteOperation();
    }

    private void Update()
    {
        transform.DOLocalMove(transform.position + transform.up * Time.deltaTime * speed, Time.deltaTime, false).SetEase(launchEase);
    }


    public override void ExecuteOperation()
    {
        
        transform.DORotate(rotaton * releseAngle, first_ejection_time, RotateMode.FastBeyond360).SetEase(rotatonEase).SetDelay(carvePathDellay).OnComplete(() => {
            if (nextejection != null)
            {
                nextejection.enabled = true;
                this.enabled = false;
                firstagelanding.enabled = true;
            }
        });
    }
}
