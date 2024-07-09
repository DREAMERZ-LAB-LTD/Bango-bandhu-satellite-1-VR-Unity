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
    private void OnEnable()
    {
        ExecuteOperation();
    }
    public override void ExecuteOperation()
    {
        transform.parent = null;
        
        leftCover.transform.DORotate(leftCoverEndRotation, duration, RotateMode.Fast).SetEase(ease);
        rightCover.transform.DORotate(rightCoverEndRotation, duration, RotateMode.Fast).SetEase(ease);
        
        leftCover.transform.DOLocalMoveX(transform.position.x - departDistancce, duration / 2f, false);
        rightCover.transform.DOLocalMoveX(transform.position.x + departDistancce, duration / 2f, false);
    }

}
