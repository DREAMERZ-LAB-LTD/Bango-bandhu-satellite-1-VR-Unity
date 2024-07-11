using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstagelanding : MonoBehaviour
{

    [SerializeField] float scaletime = 20f;
    [SerializeField] ParticleSystem flame;
    private void OnEnable()
    {
        flame.Stop();
        transform.DORotate(Vector3.zero, scaletime/4f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad).OnComplete(() => {
            flame.Play();
            flame.simulationSpace = ParticleSystemSimulationSpace.Local;
        }
        );
        transform.DOJump(Vector3.forward * 50f, 10f, 1, scaletime, false).OnComplete(() => { gameObject.SetActive(false); });
    }
    
}
