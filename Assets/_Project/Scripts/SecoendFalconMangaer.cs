using DA_Assets.Shared;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecoendFalconMangaer : MonoBehaviour
{
    [SerializeField] Transform rokect;
    [SerializeField] Transform rokectEndPoint;
    [SerializeField] Transform earth, stage1, stage2, stage3, satalite, ray, particals, falconLandingPositon;
    [SerializeField] ParticleSystem stage2_partical;
    [SerializeField] float totalTime = 30f;
    [SerializeField] float stage1time, stage2time, stage3time, sataliteStageTime, raytime, fallbacktime, rayScale;
    [SerializeField] Transform stage3_left, stage3_right;
    [SerializeField] Animator fh_open, leftwing, rightwing;
    [SerializeField] int nextScene;
    private void Start()
    {
        particals.gameObject.SetActive(true);
        earth.DORotate(new Vector3(188.898f, -449.217f, -156.567f), totalTime, RotateMode.Fast).SetEase(Ease.Linear);
        rokect.DOScale(Vector3.one*3f, stage1time+stage2time).SetEase(Ease.Linear);

        Invoke(nameof(Stage1), stage1time);


    }
    private void Stage1() 
    {
        stage2.parent = rokect;
        particals.gameObject.SetActive(false);
       /* stage1.DORotate(Vector3.zero, stage1time / 4f, RotateMode.FastBeyond360).SetEase(Ease.OutQuad).OnComplete(() => {
            particals.gameObject.SetActive(true);
        });*/
        MoveObjectToEarth(stage1);


        Invoke(nameof(Stage2), 2f);

    }
    private void Stage2()
    {
        stage2_partical.Play();
        stage3.parent = rokect;
        float temp = stage2time;
        DOTween.To(() => temp, x => temp = x, 0f, stage2time).OnComplete(() => { 
            stage2_partical.Stop();
            MoveObjectToEarth(stage2);
            Invoke(nameof(Stage4), sataliteStageTime);
        });
        Invoke( nameof(Stage3), stage2time/2 - stage3time);

    }
    private void Stage3()
    {
        satalite.parent = rokect;
        fh_open.SetBool("Value", true);
        float temp = 5;
        DOTween.To(() => temp, x => temp = x, 0f, stage3time).OnComplete(() => 
        {
            MoveObjectToEarth(stage3);
            
        });
    }
    private void Stage4()
    {
        satalite.DOLookAt(earth.position, sataliteStageTime).OnComplete(() => {

            ray.transform.DOScale(Vector3.one * rayScale + Vector3.forward*.5f, raytime);
                
        }
        );
        leftwing.SetBool("True", true);
        rightwing.SetBool("True", true);
    }
    private void Stage5()
    {

    }
    private void MoveObjectToEarth(Transform t, float time =3f)
    {
        if (particals.gameObject.activeInHierarchy) 
        {
            float temp = 5;
            DOTween.To(() => temp, x => temp = x, 0f, fallbacktime - fallbacktime/3).OnComplete(() =>
            {
                particals.gameObject.SetActive(false);
            });
        }
       // t.DOJump(falconLandingPositon.position, 10f, 1, fallbacktime, false).OnComplete(() => { t.gameObject.SetActive(false); }).OnComplete(() => {
            t.DOMove(rokectEndPoint.position, time);
       // });
        t.DOScale(Vector3.zero, time);
    }


    ///Loading scene
    ///
    public void LoadNextScene() 
    {
        SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
    }
}
