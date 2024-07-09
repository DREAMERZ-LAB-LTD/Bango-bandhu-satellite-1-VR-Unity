using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SatelliteScript : MonoBehaviour
{
    [SerializeField] public bool isGrabe = false;
    [SerializeField] Transform targetTransform;
    [SerializeField] public Transform targetObject;

    public bool isStay = false;
    public InfoPanel _infoPanel;

    Vector3 _startRotation;
    Vector3 _localScale;

    private void Start()
    {
        targetTransform = targetObject.transform;
        _startRotation = transform.localEulerAngles;
        _localScale = transform.localScale;
        targetTransform = transform.parent;
    }


    public void OnGrabed()
    {
        if (!isGrabe)
        {
            isGrabe = true;
            transform.SetParent(null);
        }
    }


    public void ReleseGrabe()
    {
        if (isGrabe)
        {
            isGrabe = false;
            // Invoke("WaitForReset", 0.1f);
            WaitForReset();
        }
    }

    private void WaitForReset()
    {
        CancelInvoke("WaitForReset");
        if (isStay && _infoPanel != null)
        {
            MoveToTargetPosition(_infoPanel._iteamPosition);
            Debug.Log("Move to UI Pose ");

        }
        else
        {

            MoveToTargetPosition(targetObject.transform);

        }
    }

    public void MoveToTargetPosition(Transform _target)
    {
        transform.SetParent(_target);
        transform.DOScale(_localScale, 0.3f);
        transform.DOLocalRotate(_startRotation, 0.3f);
        transform.DOLocalMove(Vector3.zero, 0.3f).OnComplete(() => {
            transform.DOKill();
            transform.localEulerAngles = _startRotation;
            transform.localScale = _localScale;
        });
    }

}
