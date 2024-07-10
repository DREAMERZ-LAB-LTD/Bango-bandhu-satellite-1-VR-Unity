
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;

public class RotateAround : MonoBehaviour
{
    public Transform target;    // the object to rotate around
    public float speed;   // the speed of rotation
    private bool canMove = false;
    void Start()
    {
        if (target == null)
        {
            target = this.gameObject.transform;

        }
        //  speed += Random.Range(7.0f, 14.0f);
        canMove = true;

        

    }


    void Update()
    {
        if (!canMove) return;

        // RotateAround takes three arguments, first is the Vector to rotate around
        // second is a vector that axis to rotate around
        // third is the degrees to rotate, in this case the speed per second
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}
