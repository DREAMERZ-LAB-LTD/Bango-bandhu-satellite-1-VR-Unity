using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class FalconManager : MonoBehaviour
{
    [SerializeField] float totalLaunchtime = 180f;
    [SerializeField] float m_first_Ejact = 60;
    [SerializeField] float m_secoend_Eject = 120;
    [SerializeField] float m_last_Eject = 180;
    [SerializeField] float altatute = 20f;
    [SerializeField] Transform EndRotationReferance;

    [SerializeField] Ease LaunchingEase, rotatonEase;
    [SerializeField] List<Transform> pathTransforms;
    //launching manager
    // ejector manager
    //satalite manager
    private void Start()
    {
        Launch();

    }
    
    private Vector3[] Getpath() 
    {
        Vector3[] path = new Vector3[pathTransforms.Count];
        for (int i = 0; i < pathTransforms.Count; i++)
        {
            path[i] = pathTransforms[i].position;            
        }
        return path;
    }


    private void Launch() 
    {
        Vector3[] path = Getpath();
        Debug.Log(path.Length);
        transform.DOPath(path, totalLaunchtime, PathType.CatmullRom, PathMode.Full3D, 10, Color.red).SetLookAt(transform.forward);
        
        
    }

}
