using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStage : EjectionStage
{
    [SerializeField] GameObject leftCover, rightCover;
    [SerializeField] Vector3 leftCoverEndRotation, rightCoverEndRotation;
    [SerializeField] float duration = 3f, departDistancce =2f;
    [SerializeField] Ease ease = Ease.Linear;
    [SerializeField] SecoendStage secoendStage;
    private void OnEnable()
    {
        ExecuteOperation();
    }
    protected override void ExecuteOperation()
    {
        transform.parent = null;
        
        leftCover.transform.DORotate(leftCoverEndRotation, duration, RotateMode.Fast).SetEase(ease);
        rightCover.transform.DORotate(rightCoverEndRotation, duration, RotateMode.Fast).SetEase(ease);
        
        leftCover.transform.DOLocalMoveX(transform.position.x - departDistancce, duration / 2f, false);
        rightCover.transform.DOLocalMoveX(transform.position.x + departDistancce, duration / 2f, false).OnComplete(() => {
            Invoke(nameof(StopThirdStage), duration);
        });


    }
    private void StopThirdStage() 
    {
        nextejection.enabled = true;
        secoendStage.StopSecoendStage();
        this.enabled = false;
    }
}
