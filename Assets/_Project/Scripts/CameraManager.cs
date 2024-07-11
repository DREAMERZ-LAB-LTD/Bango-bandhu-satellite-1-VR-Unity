using DA_Assets.FCU;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform satalite;
    [SerializeField] Vector3 postionOffset = Vector3.zero, lookatOffset = Vector3.zero;
    private void Start()
    {
        //postionOffset = transform.position- satalite.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.DOLookAt(satalite.position+lookatOffset, 1f, AxisConstraint.None);
        transform.DOMove(satalite.position + postionOffset, 1f, false);
    }
}
