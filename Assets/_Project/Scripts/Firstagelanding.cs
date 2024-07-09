using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstagelanding : MonoBehaviour
{

    [SerializeField] float scaletime = 20f;
    private void OnEnable()
    {
        transform.DOScale(Vector3.zero, scaletime);
    }
}
